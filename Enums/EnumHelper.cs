using System.ComponentModel;
using System.Globalization;

namespace wpf_mvvm_exercise.Enums
{
    //Used to convert Enums to their string values based on the DescriptionAttribute. Used to make binding easier.
    public static class EnumHelper
    {
        public static string Description(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            if (field == null) 
                throw new ArgumentException($"FieldInfo cannot be found for: {nameof(value)}");

            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            
            if (attributes.Any())
                return (attributes.First() as DescriptionAttribute).Description;

            //If no description is found, replace underscores with spaces
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            return textInfo.ToTitleCase(textInfo.ToLower(value.ToString().Replace("_", " ")));
        }

        public static IEnumerable<ValueDescription> GetAllValuesAndDescriptions(Type type)
        {
            if (!type.IsEnum)
                throw new ArgumentException($"{nameof(type)} must be an enum type");

            return Enum.GetValues(type).Cast<Enum>().Select((e) => new ValueDescription() { Value = e, Description = e.Description() }).ToList();
        }
    }
}
