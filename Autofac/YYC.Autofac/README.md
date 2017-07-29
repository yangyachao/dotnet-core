## Autofac
``` C#
builder.Register(c => new ValuesServiceV2(c.Resolve<ILogger<ValuesServiceV2>>()))
                .As<IValuesService>()
                .InstancePerLifetimeScope();
```