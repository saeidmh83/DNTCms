using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Mappers;
using DNTCms.MapperProfiles;
using StructureMap.Web;

namespace DNTCms.Web.IocConfig
{
    public class AutoMapperRegistery : StructureMap.Configuration.DSL.Registry
    {
        public AutoMapperRegistery()
        {
           
            For<ConfigurationStore>().Singleton().Use<ConfigurationStore>()
                .Ctor<IEnumerable<IObjectMapper>>().Is(MapperRegistry.Mappers);

            For<IConfigurationProvider>().Use(ctx => ctx.GetInstance<ConfigurationStore>());

            For<IConfiguration>().Use(ctx => ctx.GetInstance<ConfigurationStore>());

            For<ITypeMapFactory>().Use<TypeMapFactory>();

            For<IMappingEngine>().Singleton().Use<MappingEngine>()
                                 .SelectConstructor(() => new MappingEngine(null));

            Scan(scanner =>
            {

                scanner.AddAllTypesOf<UserProfile>();
                scanner.AddAllTypesOf<Profile>().NameBy(item => item.Name);

                scanner.ConnectImplementationsToTypesClosing(typeof(ITypeConverter<,>))
                       .OnAddedPluginTypes(t => t.HybridHttpOrThreadLocalScoped());

                scanner.ConnectImplementationsToTypesClosing(typeof(ValueResolver<,>))
                    .OnAddedPluginTypes(t => t.HybridHttpOrThreadLocalScoped());
            });
        }
    }
}
