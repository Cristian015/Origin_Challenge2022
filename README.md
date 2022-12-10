# Origin_Challenge2022

Crear BD en sql server: "atm"

agregar al archivo appsettings.json la siguiente linea:
"ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost; initial Catalog=atm;User Id=sa;Password=tupassword;"
  },
  
  
  ejecutar en la terminal de vs el siguiente comando:
  
  dotnet ef migrations add MigracionInicial -p BusinessLogic -s WebApi -o Data/Migrations
  
  para crear las migraciones de las tablas.
  
  
  ![image](https://user-images.githubusercontent.com/16199425/206824672-d06ed6cc-eead-43d1-90b4-4c331670780d.png)
