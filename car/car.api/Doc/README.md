## Tecnología
    - Base de datos SqlServer
      - tiene 5 tablas
        - user
        - location
        - car
        - Reserve
        - sale
      - En la carpeta del proyecto llamada creacion_db están 2 archivos. con 1 se podrá crear las tablas de la db llamada "rent_car"
    - El back es un api creada en ".Net 8" c# 12

## Api w.sale.car.api
### Se presentan 5 controladores
- User
- Location
- Car
- Reserve
- Sale

Estos tienen 4 métodos en común:

    - Created [Users, Locations, Cars, Reserves, Sales]
    - Update [Users, Locations, Cars, Reserves, Sales]
    - Delete [Users, Locations, Cars, Reserves, Sales]
    - Search. list of [Users, Locations, Cars, Reserves, Sales]

## Filtros
- Para los endpoints de consultar también se puede filtrar. para eso se debe enviar los datos con el siguiente formato. 
    * Para la creación los registros se elimina el id de la tabla y se creará correctamente
    * Para la actualización no se modificarán los id principales.
    ** para las ventas no se podrá modificar  
    * para tener una búsqueda efectiva se debe modificar le json de entrada. se eliminan los nodos que no se deben considerar
    * Cuando hay rango de fechas será de salida a llegada. Es decir de mayor a menor.
    * Cuando solo hay una fecha será filtrado con el criterio mayor a esa fecha.
    
## Actualización
- Cuando se quiera actualizar el un registro se tiene que enviar el Id del nodo a modificar. 
- Los demás atributos si se modifican es decir un valor diferente de cero o vació
 se actualizarán respectivamente. Si se enviar vacios o en cero el sistema omitira estos campos.

## Objetivo central del API
- Esta api permite crear los insumos para poder realizar una reserva y venta de un vehículo. 
  * Para que este proceso se pueda realizar se deben cumplir los siguientes pasos.
    - Crear los users (vendor, buyer)
    - Crear las ubicaciones
    - Crear los vehículos

    
 Después se podrá pasar a crear la reserva y venta. si los Identificadores de los 3 nodos anteriormente mencionados no corresponden a 
 ids reales en la base de datos. la creación de la reserva fallará indicando cual de los 3 nodos ha fallado.  Si todo está ok se 
 crea la reserva y posterior a eso se podrá realizar la venta.

 --------------------------------------------------------------------------------------------------------------------------------------


 ## Technology
     - SqlServer database
       - has 5 tables
         -user
         - location
         - car
         - Reserve
         - sale
       - In the project folder called creation_db there are 2 files. with 1 you can create the tables of the db called "rent_car"
     - The back is an api created in ".Net 8" c# 12

## Api w.sale.car.api
### 5 drivers are presented
- User
- Location
- Car
- Reserve
- sale

These have 4 methods in common:

     - Created [Users, Locations, Cars, Reserves, Sales]
     - Update [Users, Locations, Cars, Reserves, Sales]
     - Delete [Users, Locations, Cars, Reserves, Sales]
     -Search. list of [Users, Locations, Cars, Reserves, Sales]

## Filters
- For query endpoints you can also filter. For this, the data must be sent in the following format.
     * To create the records, the table id is removed and it will be created correctly
     * The main ids will not be modified for the update.
     **for sales it cannot be modified
     * to have an effective search you must modify the input json. nodes that should not be considered are removed
     * When there is a date range it will be from departure to arrival. That is, from highest to lowest.
     * When there is only one date it will be filtered with the criterion greater than that date.
    
## Update
- When you want to update a record, you have to send the Id of the node to modify.
- The other attributes are modified, that is, a value different from zero or empty.
  will be updated respectively. If empty or zero are sent, the system will omit these fields.

## Core goal of the API
- This API allows you to create the inputs to make a reservation and sale of a vehicle.
   * For this process to be carried out, the following steps must be completed.
     - Create users (seller, buyer)
     - Create locations
     - Create cars

    
  Then you can go on to create the reservation and sale. if the Identifiers of the 3 nodes mentioned above do not correspond to
  real ids in the database. The creation of the reservation will fail indicating which of the 3 nodes has failed. If everything is ok
  Create the reservation and after that the sale can be made.