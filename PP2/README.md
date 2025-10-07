# Tarea Programada 2 - TP2 Calculadora Binaria

**Nombre:** Sebastian Vargas Pacheco  
**Carné:** FH23015557  

---

## Comandos de dotnet utilizados (CLI).

**Respuesta:**
mkdir PP2, cd PP2, dotnet new sln --name PracticaProgramada2, dotnet new mvc -f net8.0 -o PP2.Web, dotnet sln add PP2.Web/PP2.Web.csproj, cd PP2.Web, dotnet build, dotnet run

## Recursos Consultados

- https://chat.openai.com/

---

## Prompts utilizados

### ChatGPT

**Prompt:**  
En C# con ASP.NET Core MVC osea net 8.0 cual seria la expresion regular correcta para poder validar un string solo tenga los caracteres 0 y 1 y como se usaria en un [RegularExpression] de Data Annotations ?

**Respuesta:**  
La expresión regular adecuada es:

^[01]+$

Explicación rápida:

^ ancla el inicio de la cadena.

[01] permite solo los caracteres 0 o 1.

+ exige al menos un carácter (longitud > 0).

$ ancla el final de la cadena.

Uso en ASP.NET Core MVC (Data Annotations):

[RegularExpression(@"^[01]+$", ErrorMessage = "Por favor corrija lo siguiente: el campo solo puede contener los caracteres 0 y 1.")]
public string A { get; set; } = string.Empty;

---

### ChatGPT

**Prompt:**  
En este caso igual en ASP.NET Core MVC net 8.0 usando un static ValidationResult? ValidateEvenLength(string value, ValidationContext context) me podrias confirmar que lo mas simple es para hacer el mensaje de error es usar el context.MemberName ? la idea es que el mensaje logre identificar el campo que fallo ya sea A o B, no quiero que me des otras alternativas solo que me digas si ese context.MemberName podria funcionarme para esta ocasion. 

**Respuesta:**  
Sí: usar context.MemberName es correcto y funciona bien para identificar la propiedad que está fallando (el nombre real del miembro del modelo, ej. A o B).

---

### ChatGPT

**Prompt:**  
Tengo estos métodos OpAND/OpOR/OpXOR que me dan resultados binarios de 8 bits, pero leí mejor las instrucciones y vi que no necesito mostrar ceros a la izquierda en los resultados  (solo en a y b).
Te paso mi código actual:

private string OpAND(string a, string b)
{
    char[] result = new char[8];
    for (int i = 0; i < 8; i++)
        result[i] = (a[i] == '1' && b[i] == '1') ? '1' : '0';
    return new string(result);
}

private string OpOR(string a, string b)
{
    char[] result = new char[8];
    for (int i = 0; i < 8; i++)
        result[i] = (a[i] == '1' || b[i] == '1') ? '1' : '0';
    return new string(result);
}

private string OpXOR(string a, string b)
{
    char[] result = new char[8];
    for (int i = 0; i < 8; i++)
        result[i] = (a[i] != b[i]) ? '1' : '0';
    return new string(result);
}
ocupo que lo modifiques de tal manera que el retorno no tenga ceros a la izquierda y si todo es cero, devuelva "0".

**Respuesta:**  
        private string OpAND(string a, string b)
        {
            char[] result = new char[8];
            for (int i = 0; i < 8; i++)
            {
                result[i] = (a[i] == '1' && b[i] == '1') ? '1' : '0';
            }
            return new string(result).TrimStart('0') == "" ? "0" : new string(result).TrimStart('0');
        }

        private string OpmOR(string a, string b)
        {
            char[] result = new char[8];
            for (int i = 0; i < 8; i++)
            {
                result[i] = (a[i] == '1' || b[i] == '1') ? '1' : '0';
            }
            return new string(result).TrimStart('0') == "" ? "0" : new string(result).TrimStart('0');
        }

        private string OpXOR(string a, string b)
        {
            char[] result = new char[8];
            for (int i = 0; i < 8; i++)
            {
                result[i] = (a[i] != b[i]) ? '1' : '0';
            }
            return new string(result).TrimStart('0') == "" ? "0" : new string(result).TrimStart('0');
        }

---

**Pregunta:**
Quiero que me ayudes con una vista para index.cshtml en asp.net core mvc net 8.0 en este caso para una calculadora binaria, para que te hagas una idea quiero un bloque de estilos css lo mas sencillo posible basicamente que centre el contenido, que use el contenedor en color blanco, en la tabla que el encabezado vaya de color azul y sus respectivos nombres en color blanco y tambien el boton de calcular de color azul y letras blancas, dame solamente el style completo porfa, este es el código para que te ayudes: 
@model PP2.Web.Models.OperacionBinaria
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Calculadora Binaria</title>
</head>
<body>
    <div class="container">
        <h1>Calculadora Binaria</h1>
        
        @if (!ViewData.ModelState.IsValid)
        {
            <div class="validation-summary">
                <strong>Por favor corrija los siguientes errores:</strong>
                <ul>
                    @foreach (var error in ViewData.ModelState.Values.SelectMany(v => v.Errors))
                    {
                        <li>@error.ErrorMessage</li>
                    }
                </ul>
            </div>
        }

        <form method="post">
            <div class="form-group">
                <label for="a">a</label>
                <input type="text" id="a" name="a" value="@Model.a" />
                <span asp-validation-for="a" class="error"></span>
            </div>

            <div class="form-group">
                <label for="b">b</label>
                <input type="text" id="b" name="b" value="@Model.b" />
                <span asp-validation-for="b" class="error"></span>
            </div>

            <button type="submit">Calcular</button>
        </form>

        @if (!string.IsNullOrEmpty(Model.aBinary) && ViewData.ModelState.IsValid)
        {
            <table>
                <thead>
                    <tr>
                        <th>Ítem</th>
                        <th>Binario</th>
                        <th>Octal</th>
                        <th>Decimal</th>
                        <th>Hexadecimal</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td><strong>a</strong></td>
                        <td>@Model.aBinary</td>
                        <td>@Convert.ToString(Convert.ToInt32(Model.aBinary, 2), 8)</td>
                        <td>@Convert.ToInt32(Model.aBinary, 2)</td>
                        <td>@Convert.ToString(Convert.ToInt32(Model.aBinary, 2), 16).ToUpper()</td>
                    </tr>
                    <tr>
                        <td><strong>b</strong></td>
                        <td>@Model.bBinary</td>
                        <td>@Convert.ToString(Convert.ToInt32(Model.bBinary, 2), 8)</td>
                        <td>@Convert.ToInt32(Model.bBinary, 2)</td>
                        <td>@Convert.ToString(Convert.ToInt32(Model.bBinary, 2), 16).ToUpper()</td>
                    </tr>
                    <tr>
                        <td><strong>a AND b</strong></td>
                        <td>@Model.andResult</td>
                        <td>@Convert.ToString(Convert.ToInt32(Model.andResult, 2), 8)</td>
                        <td>@Convert.ToInt32(Model.andResult, 2)</td>
                        <td>@Convert.ToString(Convert.ToInt32(Model.andResult, 2), 16).ToUpper()</td>
                    </tr>
                    <tr>
                        <td><strong>a OR b</strong></td>
                        <td>@Model.orResult</td>
                        <td>@Convert.ToString(Convert.ToInt32(Model.orResult, 2), 8)</td>
                        <td>@Convert.ToInt32(Model.orResult, 2)</td>
                        <td>@Convert.ToString(Convert.ToInt32(Model.orResult, 2), 16).ToUpper()</td>
                    </tr>
                    <tr>
                        <td><strong>a XOR b</strong></td>
                        <td>@Model.xorResult</td>
                        <td>@Convert.ToString(Convert.ToInt32(Model.xorResult, 2), 8)</td>
                        <td>@Convert.ToInt32(Model.xorResult, 2)</td>
                        <td>@Convert.ToString(Convert.ToInt32(Model.xorResult, 2), 16).ToUpper()</td>
                    </tr>
                    <tr>
                        <td><strong>a + b</strong></td>
                        <td>@Model.sumResult</td>
                        <td>@Convert.ToString(Convert.ToInt32(Model.sumResult, 2), 8)</td>
                        <td>@Convert.ToInt32(Model.sumResult, 2)</td>
                        <td>@Convert.ToString(Convert.ToInt32(Model.sumResult, 2), 16).ToUpper()</td>
                    </tr>
                    <tr>
                        <td><strong>a • b</strong></td>
                        <td>@Model.multiplyResult</td>
                        <td>@Convert.ToString(Convert.ToInt32(Model.multiplyResult, 2), 8)</td>
                        <td>@Convert.ToInt32(Model.multiplyResult, 2)</td>
                        <td>@Convert.ToString(Convert.ToInt32(Model.multiplyResult, 2), 16).ToUpper()</td>
                    </tr>
                </tbody>
            </table>
        }
    </div>
</body>
</html> 

**Respuesta:**
<style>
        body {
            font-family: Arial, sans-serif;
            max-width: 900px;
            margin: 50px auto;
            padding: 20px;
            background-color: #f5f5f5;
        }
        .container {
            background-color: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }
        h1 {
            color: #333;
            text-align: center;
        }
        .form-group {
            margin-bottom: 20px;
        }
        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #555;
        }
        input[type="text"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            font-size: 16px;
            box-sizing: border-box;
        }
        button {
            background-color: #007bff;
            color: white;
            padding: 12px 30px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            width: 100%;
        }
        button:hover {
            background-color: #0056b3;
        }
        .error {
            color: #dc3545;
            font-size: 14px;
            margin-top: 5px;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 30px;
        }
        th, td {
            padding: 12px;
            text-align: left;
            border: 1px solid #ddd;
        }
        th {
            background-color: #007bff;
            color: white;
        }
        tr:nth-child(even) {
            background-color: #f9f9f9;
        }
        .validation-summary {
            background-color: #f8d7da;
            border: 1px solid #f5c6cb;
            color: #721c24;
            padding: 15px;
            border-radius: 4px;
            margin-bottom: 20px;
        }
    </style>