using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VivaldiHiddenLevers.Application.Interfaces.Mapping;

namespace VivaldiHiddenLevers.Application.Infrastructure.AutoMapper
{
    public sealed class Map
    {
        public Type Source { get; set; }
        public Type Destination { get; set; }
    }

    public static class MapperProfileHelper
    {
        public static IList<Map> LoadStandardMappings(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var mapsFrom = (
                from type in types
                from instance in type.GetInterfaces()
                where
                    instance.IsGenericType && instance.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                    !type.IsAbstract &&
                    !type.IsInterface
                select new Map
                {
                    Source = instance.GetGenericArguments().First(),
                    Destination = type
                });

            var mapsTo = (
                from type in types
                from instance in type.GetInterfaces()
                where
                    instance.IsGenericType && instance.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                    !type.IsAbstract &&
                    !type.IsInterface
                select new Map
                {
                    Source = type,
                    Destination = instance.GetGenericArguments().First()
                });

            return mapsFrom.Concat(mapsTo).ToList();
        }

        public static IList<IHaveCustomMapping> LoadCustomMappings(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var customMaps = (
                    from type in types
                    from instance in type.GetInterfaces()
                    where
                        typeof(IHaveCustomMapping).IsAssignableFrom(type) &&
                        !type.IsAbstract &&
                        !type.IsInterface
                    select (IHaveCustomMapping)Activator.CreateInstance(type)).ToList();

            return customMaps;
        }
    }
}
