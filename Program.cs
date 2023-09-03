// See https://aka.ms/new-console-template for more information
using awesomedi;
using awesomedi.DependencyInjection;

var services = new ServiceCollection();

// services.RegisterSingleton<RandomGuidGenerator>();
services.RegisterTransient<RandomGuidGenerator>();
// services.RegisterSingleton(new RandomGuidGenerator());
services.RegisterTransient<ISomeService, SomeService1>();
services.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();

var container = services.BuildContainer();
var serviceFirst = container.GetService<ISomeService>();
var serviceSecond = container.GetService<ISomeService>();

serviceFirst.PrintSomething();
serviceSecond.PrintSomething();
