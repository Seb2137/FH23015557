using System.ComponentModel.DataAnnotations;

namespace PP2.Web.Models
{

    public class OperacionBinaria
    { 
        [Required(ErrorMessage = "Por favor corrija  lo siguiente: El campo 'a' es requerido.")]
        [RegularExpression(@"^[01]+$", ErrorMessage = "Por favor corrija  lo siguiente: El campo 'a' solo puede contener los caracteres 0 y 1.")]
        [StringLength(8, MinimumLength = 1, ErrorMessage = "Por favor corrija  lo siguiente: El campo 'a' debe tener entre 1 y 8 caracteres.")]
        [CustomValidation(typeof(OperacionBinaria), nameof(ValidateEvenLength))]
        public string a { get; set; } = string.Empty;

        [Required(ErrorMessage = "Por favor corrija  lo siguiente: El campo 'b' es requerido.")]
        [RegularExpression(@"^[01]+$", ErrorMessage = "Por favor corrija  lo siguiente: El campo 'b' solo puede contener los caracteres 0 y 1.")]
        [StringLength(8, MinimumLength = 1, ErrorMessage = "Por favor corrija  lo siguiente: El campo 'b' debe tener entre 1 y 8 caracteres.")]
        [CustomValidation(typeof(OperacionBinaria), nameof(ValidateEvenLength))]
        public string b { get; set; } = string.Empty;

        public static ValidationResult? ValidateEvenLength(string value, ValidationContext context)
        {
            if (string.IsNullOrEmpty(value))
                return ValidationResult.Success;

            if (value.Length % 2 != 0)
            {
                var memberName = context.MemberName ?? "campo";
                return new ValidationResult($"El campo '{memberName}' debe tener una longitud múltiplo de 2.");
            }

            return ValidationResult.Success;
        }

        public string aBinary { get; set; } = string.Empty;
        public string bBinary { get; set; } = string.Empty;
        public string andResult { get; set; } = string.Empty;
        public string orResult { get; set; } = string.Empty;
        public string xorResult { get; set; } = string.Empty;
        public string sumResult { get; set; } = string.Empty;
        public string multiplyResult { get; set; } = string.Empty;
    }
}
    

