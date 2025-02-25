# Presentación DevSummit – API en C#

Este repositorio contiene un ejemplo de proyecto en **C#** que ilustra cómo interactuar con una API para **obtener un token** y, posteriormente, **crear un producto**, **crear un cliente** y **crear una factura**.

El código ha sido preparado especialmente para una presentación del **DevSummit**, enfocada en demostrar la integración paso a paso con servicios externos a través de solicitudes HTTP y manejo de tokens.

## Tabla de Contenidos

- [Descripción General](#descripción-general)
- [Requisitos](#requisitos)
- [Instalación y Ejecución](#instalación-y-ejecución)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Flujo de Funcionalidades](#flujo-de-funcionalidades)
- [Licencia](#licencia)

## Descripción General

Este ejemplo muestra cómo:

1. **Solicitar un token** a una API que provee autenticación.
2. **Usar el token** para realizar llamadas posteriores y proteger recursos críticos.
3. **Crear un producto**, **crear un cliente** y **generar una factura** utilizando los endpoints correspondientes.

Su objetivo principal es que los desarrolladores comprendan el flujo de trabajo típico en integraciones con servicios que requieren autenticación basada en tokens.

## Requisitos

- **.NET 6 o superior** (SDK instalado).
- **Visual Studio 2022**, **Visual Studio Code** o cualquier otro editor compatible con proyectos .NET.
- Credenciales o configuración de acceso (URL base y endpoints) de la API a la que se llamará para obtener el token y crear los registros.

## Instalación y Ejecución

1. **Clonar** este repositorio:
   ```bash
   git clone https://github.com/tu-usuario/nombre-del-repo.git
   cd nombre-del-repo
   ```
2. **Ejecutar** el proyecto:
   ```bash
   dotnet run
   ```
   *(También puedes abrir el **`.sln`** en Visual Studio y pulsar F5.)*

## Estructura del Proyecto

```plaintext
nombre-del-repo/
│   README.md
│   nombre-del-repo.sln
└───src/
    └───NombreDelProyecto/
        │   Program.cs
        │   appsettings.json
        └── Services/
            │   AuthService.cs
            │   ProductService.cs
            │   ClientService.cs
            │   InvoiceService.cs
        └── Models/
            │   Product.cs
            │   Client.cs
            │   Invoice.cs
```

- **Program.cs**: Punto de entrada de la aplicación, gestiona el flujo de autenticación y llamadas a la API.
- **Services**: Clases que manejan las solicitudes HTTP (`AuthService`, `ProductService`, `ClientService`, `InvoiceService`).
- **Models**: Clases que representan los objetos de negocio (`Product`, `Client`, `Invoice`).

## Flujo de Funcionalidades

### Ejemplo en C# para Obtención de Token
```csharp
public async Task ObtenerTokenAsync()
{
    var client = new HttpClient();
    var requestData = new { client_id = "tu-client-id", client_secret = "tu-client-secret", grant_type = "client_credentials" };
    var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
    
    HttpResponseMessage response = await client.PostAsync("https://api.ejemplo.com/token", content);
    string responseBody = await response.Content.ReadAsStringAsync();
    
    Console.WriteLine(response.IsSuccessStatusCode ? $"Token obtenido: {responseBody}" : $"Error: {response.StatusCode}");
}
```

### Ejemplo en C# para Creación de Producto
```csharp
public async Task CrearProductoAsync(string token)
{
    var productData = new { nombre = "Producto A", precio = 100 };
    var content = new StringContent(JsonSerializer.Serialize(productData), Encoding.UTF8, "application/json");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    HttpResponseMessage response = await client.PostAsync("https://api.ejemplo.com/productos", content);
    
    string responseBody = await response.Content.ReadAsStringAsync();
    Console.WriteLine(response.IsSuccessStatusCode ? $"Producto creado: {responseBody}" : $"Error: {response.StatusCode}");
}
```

### Ejemplo en C# para Creación de Cliente
```csharp
public async Task CrearClienteAsync(string token)
{
    var clientData = new { nombre = "Cliente X", email = "cliente@ejemplo.com" };
    var content = new StringContent(JsonSerializer.Serialize(clientData), Encoding.UTF8, "application/json");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    HttpResponseMessage response = await client.PostAsync("https://api.ejemplo.com/clientes", content);
    
    string responseBody = await response.Content.ReadAsStringAsync();
    Console.WriteLine(response.IsSuccessStatusCode ? $"Cliente creado: {responseBody}" : $"Error: {response.StatusCode}");
}
```

### Ejemplo en C# para Creación de Factura
```csharp
public async Task CrearFacturaAsync(string token)
{
    var invoiceData = new { clienteId = 1, productos = new[] { new { id = 10, cantidad = 2 } } };
    var content = new StringContent(JsonSerializer.Serialize(invoiceData), Encoding.UTF8, "application/json");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    HttpResponseMessage response = await client.PostAsync("https://api.ejemplo.com/facturas", content);
    
    string responseBody = await response.Content.ReadAsStringAsync();
    Console.WriteLine(response.IsSuccessStatusCode ? $"Factura creada: {responseBody}" : $"Error: {response.StatusCode}");
}
```

## Licencia

Este proyecto se ofrece bajo la [MIT License](LICENSE). Puedes usarlo y modificarlo libremente, siempre que incluyas la nota de licencia correspondiente.

