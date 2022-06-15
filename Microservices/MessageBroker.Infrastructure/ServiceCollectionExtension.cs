﻿using MessageBroker.Core;
using MessageBroker.Infrastructure.Interfaces;
using MessageBroker.Infrastructure.RabbitMq;
using MessageBroker.Infrastructure.RabbitMq.Builder;
using MessageBroker.Infrastructure.RabbitMq.Builder.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBroker.Infrastructure;

public static class ServiceCollectionExtension
{
    public static void AddMessageBrokerPubSubServices(this IServiceCollection services, RabbitMqConfiguration configuration)
    {
        services.AddSingleton(_ => new RabbitMqChannelBuilder(configuration));
        services.AddSingleton<IPublisher, Publisher>();
        services.AddSingleton<IPublisherAdapter, PublisherRabbitMqAdapter>();
        services.AddSingleton<ISubscriber, Subscriber>();
        services.AddSingleton<ISubscriberAdapter, SubscriberRabbitMqAdapter>();
    }
}