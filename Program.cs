using System;

Console.WriteLine("SISTEMA DE DIAGNÓSTICO DE MOTORES");
Console.WriteLine();

string respuesta = "s";

// Ciclo while para diagnosticar cantidad desconocida de motores
while (respuesta.ToLower() == "s")
{
    // Crear un objeto de la clase Motor
    Motor motor1 = new Motor();

    // Capturar la información del objeto
    Console.Write("Ingrese el identificador del motor: ");
    motor1.Identificador = Console.ReadLine() ?? "Sin ID";

    // Usar ciclo for para capturar las 4 mediciones
    for (int i = 0; i < 4; i++)
    {
        bool entradaValida = false;

        while (!entradaValida)
        {
            Console.Write($"Ingrese la medición de corriente {i + 1} (en A): ");

            try
            {
                double lectura = Convert.ToDouble(Console.ReadLine());
                motor1.Corrientes[i] = lectura;
                entradaValida = true;
            }
            catch
            {
                Console.WriteLine("Error: Ingrese un valor numérico correcto.");
            }
        }
    }

    // Solicitar al objeto que calcule su promedio
    double promedio = motor1.CalcularPromedio();

    // Mostrar resultados
    Console.WriteLine();
    Console.WriteLine($"Motor ID: {motor1.Identificador}");
    Console.WriteLine($"Promedio de corriente: {promedio:F2} A");
    Console.WriteLine($"Estado: {motor1.ObtenerDiagnostico()}");

    Console.WriteLine();
    Console.Write("¿Desea registrar otro motor? (s/n): ");
    respuesta = Console.ReadLine() ?? "n";
    Console.WriteLine();
}


// Definición de la clase
class Motor
{
    // Propiedades
    public string Identificador { get; set; } = "";

    public double[] Corrientes { get; set; } = new double[4];


    // Método para calcular el promedio
    public double CalcularPromedio()
    {
        double suma = 0;
        double promedio;

        for (int i = 0; i < 4; i++)
        {
            suma = suma + Corrientes[i];
        }

        promedio = suma / 4.0;

        return promedio;
    }


    // Método para determinar el estado
    public string ObtenerDiagnostico()
    {
        double promedio = CalcularPromedio();

        if (promedio <= 5.0)
        {
            return "NORMAL";
        }
        else
        {
            return "REQUIERE MANTENIMIENTO";
        }
    }
}