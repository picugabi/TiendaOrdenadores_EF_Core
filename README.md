# TiendaOrdenadores_EF_Core
Aplicación Web MVC con EntityFramework Core 6.0
CodeFirst:
Creación de componentes y ordenadores mayoritariamente con seeders. Uso de validadores de los modelos mediante Data Annotations. Uso de cadena de conexion con el localdbExpress de Visual Studio con ruta relativa y
repositorios para inyeccion de dependencias. En mi caso tengo como ejemplo un repositorio que uso en el controlador y otro llamado Fake para los tests como ejemplo.Para mis modelos he implementado relaciones tanto
de "1 to many" como "many to many". Vistas con paginas RAZOR de cada modelo con su repositorio correspondiente.

DbFirst: Scaffolding del code first para crear los modelos desde la base de datos.


Patrones usados: Factory Method, Repository, Validator, Adapter, Builder.

