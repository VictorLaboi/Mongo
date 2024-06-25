using ProyectoMongo2024;
using System.Linq.Expressions;

Alumno alumno = new Alumno();
/*
alumno.Nombre = "Conrado224";
alumno.Apellido = "Quezadadasdas";
alumno.Matricula = "159357";
alumno.Grupo = "scomm62asdas";

Console.WriteLine("Insertando un elemento");
alumno.Agregar(alumno);
Console.WriteLine("Elemento agregado");
*/
Alumno alumnoPorMatricula = new Alumno();
alumnoPorMatricula = alumnoPorMatricula.ConsultarPorMatricula("159357");
if (alumnoPorMatricula != null)
{
    Console.WriteLine(alumnoPorMatricula.Nombre);
}
Console.WriteLine("////////////////CONSULTA DE REGISTROS CON MISMA MATRICULA///////////////////////");
List<Alumno> alumnos = alumno.ConsultarTodos("159357");

foreach (var i in alumnos)
{
    Console.WriteLine(i);
}





/*Alumno alumnoEditar = new Alumno();
alumnoEditar = alumnoEditar.ConsultarPorMatricula("123456");
alumnoEditar.Grupo = "scomm61";
alumnoEditar.Actualizar("123456", alumnoEditar);

Alumno alumnoEditar2 = new Alumno();
alumnoEditar2.Eliminar("159357");*/

