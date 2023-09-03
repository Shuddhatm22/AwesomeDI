# AwesomeDI
In order to understand dependency injecrtion better, tried to implement my own DI Container.
Functionalities
- handle registering and resolving singleton dependency
- handle registering and resolving transient dependency
- recursion to handle internal dependencies / constructor injection

Future Work
- add support for scoped dependencies
- add support for cyclic dependencies and error handling
- manage lifetime of objects
- improve resolver methods by adding support for primitive types like int, string etc.
