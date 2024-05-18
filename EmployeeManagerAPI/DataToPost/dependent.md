Aquí tienes ejemplos de JSON para realizar solicitudes POST a la entidad `Dependent`. Un dependiente representa una persona dependiente de un empleado, con nombre, apellido, relación, sexo, fecha de nacimiento y el SSN del empleado asociado.

### Entity: Dependent

Este archivo contiene ejemplos de JSON para realizar solicitudes POST a la entidad `Dependent`.

#### Ejemplo 1: Hijo

```json
{
    "FirstName": "Carlos",
    "LastName": "García",
    "Relationship": "Hijo",
    "Sex": "Masculino",
    "BirthDate": "2010-05-15T00:00:00Z",
    "EmployeeSSN": "123456789"
}
```

Este JSON representa la creación de un dependiente llamado Carlos García, quien es hijo de un empleado con el SSN `123-45-6789`.

#### Ejemplo 2: Cónyuge

```json
{
    "FirstName": "Ana",
    "LastName": "Martínez",
    "Relationship": "Cónyuge",
    "Sex": "Femenino",
    "BirthDate": "1985-07-22T00:00:00Z",
    "EmployeeSSN": "345678901"
}
```

Este JSON representa la creación de un dependiente llamada Ana Martínez, quien es cónyuge de un empleado con el SSN `987-65-4321`.

#### Ejemplo 3: Padre

```json
{
    "FirstName": "José",
    "LastName": "López",
    "Relationship": "Padre",
    "Sex": "Masculino",
    "BirthDate": "1950-03-10T00:00:00Z",
    "EmployeeSSN": "234567890"
}
```

Este JSON representa la creación de un dependiente llamado José López, quien es padre de un empleado con el SSN `123-45-6789`.
