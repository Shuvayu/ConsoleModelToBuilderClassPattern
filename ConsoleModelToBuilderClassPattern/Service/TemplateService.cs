using ConsoleModelToBuilderClassPattern.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConsoleModelToBuilderClassPattern.Service
{
    public class TemplateService
    {
        public static string PopulateClassTemplate<TEntity>() where TEntity : class
        {
            try
            {
                var withFunctionList = new List<string>();
                var withConstructorPropertyList = new List<string>();
                var propertyInfo = typeof(TEntity).GetProperties();
                foreach (PropertyInfo propInfo in propertyInfo)
                {
                    withFunctionList.Add(ClassTemplate.PopulateClassWithFunctionStructure(typeof(TEntity).Name, propInfo.Name, propInfo.PropertyType.Name.ToLower()));
                    withConstructorPropertyList.Add(ClassTemplate.PopulateClassConstructorStructure(propInfo.Name, propInfo.PropertyType.Name.ToLower()));
                }

                return ClassTemplate.PopulateClassStructure(typeof(TEntity).Name, withFunctionList, withConstructorPropertyList);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}