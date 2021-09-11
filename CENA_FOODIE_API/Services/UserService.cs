using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CENA_FOODIE_API.Entities;
using CENA_FOODIE_API.Helpers;
using CENA_FOODIE_API.Model;
using CENA_FOODIE_API.Model.Response;
using CENA_FOODIE_API.Repository;
using Microsoft.AspNetCore.ResponseCaching;
using System.Data;
using System.Security.Cryptography;

namespace CENA_FOODIE_API.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        ResponseSingle Login(string username, string password, bool isBusiness);
        User GetById(int id);
        ResponseSingle Create(User user, string password);
        ResponseSingle Approve(string username);
        ResponseSingle GetInfor(string username, bool isBusiness);
        ResponseExecute UpdateInfor(string username, bool isBusiness, User user);
        ResponseExecute UpdateToken(RefreshToken refreshToken, string username);
        RefreshToken GenerateRefreshToken(User user);
        string GenerateRefreshToken();
        ResponseExecute RevokeToken(string username);
    }
    public class UserService : IUserService
    {
        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            User user = new User();
            user.user_name = username;

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.user_pwd_hash = passwordHash;
            user.user_pwd_salt = passwordSalt;

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.user_pwd_hash, user.user_pwd_salt))
                return null;

            // authentication successful
            return user;
        }

        public ResponseSingle Create(User user, string password)
        {
            ResponseSingle response = new ResponseSingle();
            // validation
            if (string.IsNullOrWhiteSpace(password))
            {
                response.SetError("Password đang để trống");
                return response;
            }

            user.user_name = user.user_name.ToLower();

            if (string.IsNullOrEmpty(user.user_name))
            {
                response.SetError("Username đang để trống");
                return response;
            }

            bool isExist = LoginRepository.CHECK_EXIST(user.user_name);

            if (!isExist)
            {
                response.SetError("Tên đăng nhập \"" + user.user_name + "\" đã tồn tại");
                return response;
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.user_pwd_hash = passwordHash;
            user.user_pwd_salt = passwordSalt;

            var create = LoginRepository.REGISTER(user);
            if (create.Root["id"].ToString() == "1")
            {
                response.data = user;
                response.success = true;
                response.message = "Đăng ký thành công";
            }
            else
            {
                response.SetError("Đăng ký thất bại");
            }

            return response;
        }

        public ResponseSingle Login(string username, string password, bool isBusiness)
        {
            ResponseSingle response = new ResponseSingle();

            username = username.ToLower();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.SetError("Username hoặc password đang để trống");
                return response;
            }

            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_USER_NAME", username);
                param.Add("P_IS_BUSINESS", isBusiness);
                response = baseSQL.GetSingle("LOGIN_LAY_THONG_TIN_USER", param);
                if (!response.success || response.data == null)
                {
                    response.SetError("User không tồn tại");
                    return response;
                }

                if (response.data.STATUS == 0)
                {
                    response.SetError("Tài khoản chưa kích hoạt hoặc đang bị khóa");
                    return response;
                }    

                var user = response.data;
                // check if password is correct
                if (!VerifyPasswordHash(password, user.USER_PWD_HASH, user.USER_PWD_SALT))
                {
                    response.SetError("Password không đúng");
                    return response;
                }

                return response;
            }
        }
        public ResponseSingle Approve(string username)
        {
            ResponseSingle response = new ResponseSingle();
            LoginRepository.APPROVE_ACCOUNT(username);
            response.message = "Thao tác thành công";
            response.success = true;
            response.data = null;
            return response;
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public User GetById(int id)
        {
            User user = new User();
            //if (id == 1)
            //{
                user.user_id = id;
                user.full_name = "Tên";
            //}
            return user;
        }

        public ResponseSingle GetInfor(string username, bool isBusiness)
        {
            ResponseSingle response = new ResponseSingle();
            using (var baseSQL = new BaseSQL())
            {
                User user = new User();
                var param = new SQLDynamicParameters();
                param.Add("P_USER_NAME", username);
                param.Add("P_IS_BUSINESS", isBusiness);
                var infor = baseSQL.GetSingle("LOGIN_LAY_THONG_TIN_USER", param);
                if (infor.data != null)
                {
                    user.user_id = infor.data.USER_ID;
                    user.user_role = infor.data.USER_ROLE;
                    user.user_name = infor.data.USER_NAME;
                    user.full_name = infor.data.FULL_NAME;
                    user.email = infor.data.USER_EMAIL;
                    user.refresh_token = infor.data.TOKEN;
                    user.exp_date = infor.data.TOKEN_EXP_DATE;
                    if (isBusiness)
                        user.mst = infor.data.MST.ToString();
                    else
                        user.org_id = infor.data.ORG_ID.ToString();

                    response.data = user;
                    response.message = "Lấy dữ liệu thành công";
                    response.param = param;
                    response.success = true;
                }
                else
                {
                    response.data = null;
                    response.message = "Lấy dữ liệu thất bại";
                    response.param = param;
                    response.success = false;
                }
                return response;
            }
        }

        public ResponseExecute UpdateInfor(string username, bool isBusiness, User user)
        {
            ResponseExecute response = new ResponseExecute();
            if (username != user.user_name)
            {
                response.SetError("Lỗi dữ liệu");
                return response;
            }
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_USER_NAME", username);
                param.Add("P_IS_BUSINESS", isBusiness);
                var temp = baseSQL.GetSingle("LOGIN_LAY_THONG_TIN_USER", param);
                if (temp.data!= null)
                {
                    if (!VerifyPasswordHash(user.password, temp.data.USER_PWD_HASH, temp.data.USER_PWD_SALT))
                    {
                        response.SetError("Password không đúng");
                        return response;
                    }

                    if (user.new_password != null)
                    {
                        byte[] passwordHash, passwordSalt;
                        CreatePasswordHash(user.new_password, out passwordHash, out passwordSalt);
                        param.Add("P_USER_PWD_HASH", passwordHash, SqlDbType.VarBinary);
                        param.Add("P_USER_PWD_SALT", passwordSalt, SqlDbType.VarBinary);
                    }
                    else
                    {
                        param.Add("P_USER_PWD_HASH", temp.data.USER_PWD_HASH, SqlDbType.VarBinary);
                        param.Add("P_USER_PWD_SALT", temp.data.USER_PWD_SALT, SqlDbType.VarBinary);
                    }

                    param.Add("P_NAME", user.full_name);
                    param.Add("P_USER_EMAIL", user.email);
                    response = baseSQL.Execute("LOGIN_CAP_NHAT_TAI_KHOAN", param);
                }
                return response;
            }
        }

        public ResponseExecute UpdateToken(RefreshToken refreshToken, string username)
        {
            ResponseExecute response = new ResponseExecute();
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_USERNAME", username);
                param.Add("P_TOKEN", refreshToken.Token);
                param.Add("P_EXP_DATE", refreshToken.ExpiredDate);
                var temp = baseSQL.Execute("LOGIN_CAP_NHAT_TOKEN", param);
                response.id = 1;
                response.message = "Thực thi thành công";
                return response;
            }
        }

        public RefreshToken GenerateRefreshToken(User user)
        {
            RefreshToken refreshToken = new RefreshToken()
            {
                Token = GenerateRefreshToken(),
                ExpiredDate = DateTime.Now.AddMinutes(10)
            };

            UpdateToken(refreshToken, user.user_name);

            return refreshToken;
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ResponseExecute RevokeToken(string username)
        {
            ResponseExecute response = new ResponseExecute();
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_USERNAME", username);
                var temp = baseSQL.Execute("LOGIN_THU_HOI_TOKEN", param);
                response.id = 1;
                response.message = "Thực thi thành công";
                return response;
            }
        }
    }
}
