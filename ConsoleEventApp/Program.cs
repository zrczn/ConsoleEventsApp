// See https://aka.ms/new-console-template for more information
using ConsoleEventApp.Data;
using ConsoleEventApp.Validations.FieldValidators;
using ConsoleEventApp.Views;

IRegister register = new RegisterUser();
IFieldValidators fieldValidators = new UserRegistrationValidator(register);
ILogin login = new LoginUser();

IView userRegView = new UserRegistrationView(register, fieldValidators);
IView userLogIn = new UserLoginView(login);
IView mainView = new MainView(userRegView, userLogIn);

fieldValidators.InitValidatorDel();

mainView.RunView();