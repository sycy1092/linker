using System.Net;
using System.Net.Sockets;

namespace linker.messenger.tunnel.stun.proxy;

public class NoneUdpProxy : IUdpProxy
{
	public Socket Client { get; }

	public NoneUdpProxy(IPEndPoint localEndPoint)
	{
		Client = new Socket(localEndPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
		Client.Bind(localEndPoint);
	}

	public ValueTask ConnectAsync(CancellationToken cancellationToken = default)
	{
		return default;
	}

	public ValueTask CloseAsync(CancellationToken cancellationToken = default)
	{
		return default;
	}

	public ValueTask<SocketReceiveMessageFromResult> ReceiveMessageFromAsync(Memory<byte> buffer, SocketFlags socketFlags, EndPoint remoteEndPoint, CancellationToken cancellationToken = default)
	{
		return Client.ReceiveMessageFromAsync(buffer, socketFlags, remoteEndPoint, cancellationToken);
	}

	public ValueTask<int> SendToAsync(ReadOnlyMemory<byte> buffer, SocketFlags socketFlags, EndPoint remoteEP, CancellationToken cancellationToken = default)
	{
		return Client.SendToAsync(buffer, socketFlags, remoteEP, cancellationToken);
	}

	public void Dispose()
	{
		Client.Dispose();
		GC.SuppressFinalize(this);
	}
}
