using System.ComponentModel.DataAnnotations;

namespace Day06.CustomValidation
{
    public class DevidedByTwoValidationAttribute:ValidationAttribute
    {
        int z;
        public DevidedByTwoValidationAttribute(int y)
        {
            z = y;
        }      
        public override bool IsValid(object value)
        {    
            int x = (int)value;
            if(x%z== 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
