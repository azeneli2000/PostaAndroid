package md5b368ba14e6135bd56bd8cbb8a5512cbb;


public class AzurePushBroadcastReceiver
	extends md5214eafb7e7b3b7fcc363a68a6358563f.GcmBroadcastReceiverBase_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("FotoCel.AzurePushBroadcastReceiver, FotoCel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AzurePushBroadcastReceiver.class, __md_methods);
	}


	public AzurePushBroadcastReceiver ()
	{
		super ();
		if (getClass () == AzurePushBroadcastReceiver.class)
			mono.android.TypeManager.Activate ("FotoCel.AzurePushBroadcastReceiver, FotoCel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
