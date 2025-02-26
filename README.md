# Developer Summit | Autenticación en la API de a3factura y Webhooks

Este repositorio contiene un ejemplo de proyecto en **C#** que ilustra cómo interactuar con una API para **obtener un token** y, posteriormente, **subscribirse a una webhook** ,**crear un producto**, **crear un cliente** o **crear una factura**, y **recibir el evento de webhook**.

El código ha sido preparado especialmente para una presentación del **DevSummit**, enfocada en demostrar la integración paso a paso con servicios externos a través de solicitudes HTTP y manejo de tokens.

## Tabla de Contenidos

- [Descripción General](#descripción-general)
- [Requisitos](#requisitos)
- [Guia paso a paso](#guia-paso-a-paso)
    - [Paso 1: Instalación y Ejecución](#paso-1-instalación-y-ejecución) 
        - [Estructura del Proyecto](#estructura-del-proyecto)
    - [Paso 2: Ejemplo en C# para Obtención de Token](#paso-2-ejemplo-en-c-para-obtención-de-token)
    - [Paso 3: Ejemplo en C# para subscribir a un webhook](#paso-3-ejemplo-en-c-para-subscribir-a-un-webhook)
    - [Paso 4: Ejemplo en C# para Creación de Producto, Cliente o Factura de venta](#paso-4-ejemplo-en-c-para-creación-de-producto-cliente-o-factura-de-venta)
        - [1. Ejemplo en C# para Creación de Producto](#1-ejemplo-en-c-para-creación-de-producto)
        - [2. Ejemplo en C# para Creación de Cliente](#2-ejemplo-en-c-para-creación-de-cliente)
        - [3. Ejemplo en C# para Creación de Factura de venta](#3-ejemplo-en-c-para-creación-de-factura-de-venta)
    - [5. Ejemplo en C# para recibir el evento de webhook](#paso-5-ejemplo-en-c-para-recibir-el-evento-de-webhook)

- [Licencia](#licencia)

## Descripción General

Este ejemplo muestra cómo:

1. **Solicitar un token** a una API que provee autenticación.
2. **Usar el token** para realizar llamadas posteriores y proteger recursos críticos.
3. **Subscribirse a un webhook** para posteriormente obtener las notificaciones.
4. **Crear un producto**, **crear un cliente** o **generar una factura** utilizando los endpoints correspondientes.
5. **recibir el evento de webhook** utilizando nuestro get de log de webhook.

Su objetivo principal es que los desarrolladores comprendan el flujo de trabajo típico en integraciones con servicios que requieren autenticación basada en tokens.

## Requisitos

- **.NET 6 o superior** (SDK instalado).
- **Visual Studio 2022**, **Visual Studio Code** o cualquier otro editor compatible con proyectos .NET.
- Credenciales o configuración de acceso (URL base y endpoints) de la API a la que se llamará para obtener el token y crear los registros.

## Guia paso a paso 
### Paso 1: Instalación y Ejecución

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

#### Estructura del Proyecto

```plaintext
DevSummit2025/
├── Connected Services/
├── Dependencies/
├── Properties/
├── Controllers/
│   ├── CustomerController.cs
│   ├── InvoiceController.cs
│   ├── ProductController.cs
│   ├── SimuladorWebHookController.cs
│   ├── TokenController.cs
│   ├── WebHookController.cs
├── Model/
│   ├── CustomerDto.cs
│   ├── InvoiceDto.cs
│   ├── InvoiceLineDto.cs
│   ├── ProductDto.cs
│   ├── ProductGetAllDto.cs
│   ├── UserRqDto.cs
│   ├── WebHookChangesDto.cs
├── Services/
│   ├── Contract/
│   │   ├── IServiceCustomer.cs
│   │   ├── IServiceLogin.cs
│   │   ├── IServiceProduct.cs
│   │   ├── IServiceSaleInvoice.cs
│   │   ├── IServiceWebHook.cs
│   ├── Implementation/
│       ├── ServiceCustomer.cs
│       ├── ServiceLogin.cs
│       ├── ServiceProduct.cs
│       ├── ServiceSaleInvoice.cs
│       ├── ServiceWebHook.cs
├── appsettings.json
├── appsettings.Development.json
├── DevSummit2025.http
├── Program.cs
```

- **Program.cs**: Punto de entrada de la aplicación, gestiona el flujo de autenticación y llamadas a la API.
- **Controllers**: Declaran los puntos de acceso y llaman a los servicios correspondientes (`TokenController`, `ProductController`, `CustomerController`, `InvoiceController`, `WebHookController`).
- **Services**: Clases que manejan las solicitudes HTTP (`ServiceCustomer`, `ServiceLogin`, `ServiceProduct`, `ServiceSaleInvoice`, `ServiceWebHook`).
- **Models**: Clases que representan los objetos de negocio (`CustomerDto`, `InvoiceDto`, `InvoiceLineDto`, `ProductDto`, `ProductGetAllDto`, `UserRqDto`, `WebHookChangesDto`).

### Paso 2: Ejemplo en C# para Obtención de Token

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
### Paso 3: Ejemplo en C# para subscribir a un webhook

```csharp
public async Task WebhookSubscribeAsync()
{
    HttpClient client = new HttpClient();
    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://api.ejemplo.com/api/webhooks");

    request.Headers.Add("Ocp-Apim-Subscription-Key", "2kxwf5rb7ffb65dd5");
    request.Headers.Add("Authorization", "Bearer eyJhbG ...");

    request.Content = new StringContent("{\n    \"uri\": \"http://{baseaddress}/api/webhooks/incoming/a3Factura\",\n    \"entity\": \"Supplier\",\n    \"action\": \"Updated\",\n    \"secret\": \"12345678901234567890123456789012\",\n    \"isPaused\": false,\n    \"applicationName\": \"Test\",\n    \"descripion\": \"Test\"\n}");
    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

    HttpResponseMessage response = await client.SendAsync(request);
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();

    Console.WriteLine(response.IsSuccessStatusCode ? $"Response: {responseBody}" : $"Error: {response.StatusCode}");
}
```

### Paso 4: Ejemplo en C# para Creación de Producto, Cliente o Factura de venta

#### 1. Ejemplo en C# para Creación de Producto
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

#### 2. Ejemplo en C# para Creación de Cliente
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

#### 3. Ejemplo en C# para Creación de Factura de venta
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
### Paso 5: Ejemplo en C# para recibir el evento de webhook

```csharp

public async Task ReceiveWebhookNotificationAsync(string token)
{
    
    Console.WriteLine(response.IsSuccessStatusCode ? $"Notification: {responseBody}" : $"Error: {response.StatusCode}");
}

```

## Licencia

Este proyecto se ofrece bajo la [MIT License](LICENSE). Puedes usarlo y modificarlo libremente, siempre que incluyas la nota de licencia correspondiente.