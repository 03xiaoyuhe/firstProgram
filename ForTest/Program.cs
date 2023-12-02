// See https://aka.ms/new-console-template for more information
using ForTest;



Console.WriteLine("Hello, World!");


#region UserSighin
/// UserLoginOn
Console.WriteLine("\n\n----For UserSighin Test----");
ForUserSigin.ForAuthenticateUser();

#endregion



#region UserLoginOn
/// UserLoginOn
Console.WriteLine("\n\n----For UserLoginOn Test----");
ForUserLoginOn.ForCheckIfAccountExists();
ForUserLoginOn.ForRegisterUser();

#endregion


