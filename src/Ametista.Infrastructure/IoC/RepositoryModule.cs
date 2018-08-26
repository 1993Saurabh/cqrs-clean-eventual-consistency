﻿using Ametista.Core.Repository;
using Ametista.Infrastructure.Persistence.Repository;
using Autofac;

namespace Ametista.Infrastructure.IoC
{
    internal class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<CardRepository>()
                .As<ICardRepository>();
        }
    }
}