﻿using API.Context;
using API.Models;
using API.Models.ViewModel;
using System.Linq;


namespace API.Repositories.Auth
{
    public class AuthRepository
    {
        MyContext context;
        public AuthRepository(MyContext context)
        {
            this.context = context;
        }

        // hashing 
        public string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }
        public bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
        public Employee GetEmployee(string email)
        {
            var checkEmployee = context.Employees.SingleOrDefault(user => user.Email.Equals(email));
            return checkEmployee;
        }
        public User GetUserByEmail(string email)
        {
            var getEmployee = context.Employees.SingleOrDefault(_e => _e.Email.Equals(email));
            if (getEmployee != null)
            {
                var getUser = context.Users.Find(getEmployee.Id);
                return getUser;
            }
            return null;
        }
        public User Get(string username)
        {
            var checkUsername = context.Users.SingleOrDefault(user => user.Username.Equals(username));
            return checkUsername;
        }

        public User Get(int id)
        {
            var checkUsername = context.Users.Find(id);
            return checkUsername;
        }

        public string GetRolesByUserId(int id)
        {
            var user = context.Users.Find(id);
            UserRole[] userRole = context.UserRoles.Where(x => x.User_Id.Equals(id)).ToArray();
            Role role;
            if (userRole.Length > 1)
            {
                role = context.Roles.Find(1);
            }
            role = context.Roles.Find(userRole[0].Role_Id);
            return role.Name;
        }

        public User Login(Login input)
        {
            var checkEmployee = GetEmployee(input.Email);
            if (checkEmployee != null)
            {
                var checkUser = Get(checkEmployee.Id);
                if (checkUser != null)
                {
                    bool checkPass = ValidatePassword(input.Password, checkUser.Password);
                    if (checkPass != false)
                        return checkUser;
                }
            }
            return null;
        }

        public int Register(Register input)
        {
            context.Employees.Add(
                new Employee
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Email = input.Email,
                    PhoneNumber = input.PhoneNumber,
                    HireDate = input.HireDate,
                    Salary = input.Salary,
                    Job_Id = input.Job_Id,
                    Manager_Id = input.Manager_Id,
                    Department_Id = input.Department_Id
                });
            int resultAddingEmployee = context.SaveChanges();
            if (resultAddingEmployee > 0)
            {
                var currentUser = context.Employees.SingleOrDefault(_e => _e.Email.Equals(input.Email));
                context.Users.Add(
                    new User
                    {
                        Id = currentUser.Id,
                        Username = input.Username,
                        Password = HashPassword(input.Password)
                    }
                );
                int resultAddingUser = context.SaveChanges();
                if (resultAddingUser > 0)
                {

                    context.UserRoles.Add(new UserRole { User_Id = currentUser.Id, Role_Id = 2 });
                    int result = context.SaveChanges();
                    return result;
                }
            }

            return 0;
        }

        public int ChangePassword(Change_Password input)
        {
            var checkEmail = context.Employees.SingleOrDefault(_employee => _employee.Email.Equals(input.Email));
            if (checkEmail != null)
            {
                var checkUser = context.Users.Find(checkEmail.Id);
                if (checkUser != null)
                {
                    if (input.OldPassword == checkUser.Password)
                    {
                        checkUser.Password = input.NewPassword;
                        int result = context.SaveChanges();
                        return result;
                    }
                }
            }
            return 0;
        }

        public int ForgetPassword(Forget_Password input)
        {
            //var checkUsername = myContext.Users.SingleOrDefault(user => user.Username.Equals(UserName));
            var checkUser = GetUserByEmail(input.Email);
            if (checkUser != null)
            {
                checkUser.Password = input.NewPassword;
                int result = context.SaveChanges();
                return result;
            }
            return 0;
        }
    }
}
