namespace MassTransit.Registration
{
    using System;
    using Configuration;
    using GreenPipes;
    using Riders;


    public class TransportBusInstance :
        IBusInstance
    {
        readonly RiderConnectable _riders;

        public TransportBusInstance(IBusControl busControl, IHostConfiguration hostConfiguration)
            : this(busControl, hostConfiguration, new RiderConnectable())
        {
        }

        public TransportBusInstance(IBusControl busControl, IHostConfiguration hostConfiguration, RiderConnectable riders)
        {
            _riders = riders;
            BusControl = busControl;
            HostConfiguration = hostConfiguration;
        }

        public Type InstanceType => typeof(IBus);
        public IBus Bus => BusControl;
        public IBusControl BusControl { get; }

        public IHostConfiguration HostConfiguration { get; }

        public ConnectHandle ConnectRider(IRider rider)
        {
            return _riders.Connect(rider);
        }
    }
}
