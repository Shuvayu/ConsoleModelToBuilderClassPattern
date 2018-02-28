using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleModelToBuilderClassPattern.Models
{
    public static class ClassTemplate
    {
        public static string PopulateClassStructure(string Model, List<string> functionList, List<string> ConstructorList)
            => string.Format(ClassStructure, Model, FormatListIntoSingleString(ConstructorList), FormatListIntoSingleString(functionList));

        public static string PopulateClassConstructorStructure(string ModelProperty, string PropertyType)
            => string.Format(ClassConstructorStructure, ModelProperty, GetDefaultParameterValue(PropertyType));

        public static string PopulateClassWithFunctionStructure(string ModelName, string ModelProperty, string PropertyType)
            => string.Format(ClassWithFunctionStructure, ModelName, ModelProperty, FormatParameterType(PropertyType));

        private static string FormatListIntoSingleString(List<string> list)
        {
            var builder = new StringBuilder();
            foreach (var listItem in list)
            {
                builder.Append(listItem);
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }

        private static string FormatParameterType(string parameterType)
        {
            switch (parameterType)
            {
                case "int32":
                    return "int";

                default:
                    return parameterType;
            }
        }

        private static string GetDefaultParameterValue(string parameterType)
        {
            switch (parameterType)
            {
                case "int32":
                    return "0";

                case "string":
                    return "string.Empty";

                case "decimal":
                    return "0M";

                case "double":
                    return "0.0";

                case "float":
                    return "0.0";

                case "boolean":
                    return "false";

                default:
                    return "";
            }
        }

        private const string ClassConstructorStructure = @"
                                                                {0} = {1},";

        private const string ClassWithFunctionStructure = @"
                                                            internal {0}ModelBuilder With{1}({2} {1})
                                                            {{
                                                                _{0}.{1} = {1};
                                                                return this;
                                                            }}";

        private const string ClassStructure = @"
                                                internal class {0}ModelBuilder
                                                {{
                                                    private readonly {0} _{0};

                                                    internal {0}ModelBuilder()
                                                    {{
                                                        _{0} = new {0}
                                                        {{
                                                           {1}
                                                        }};
                                                    }}

                                                    {2}

                                                    internal {0} Build()
                                                    {{
                                                        return _{0};
                                                    }}
                                                }}";
    }
}