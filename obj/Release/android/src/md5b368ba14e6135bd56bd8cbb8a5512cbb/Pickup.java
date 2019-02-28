package md5b368ba14e6135bd56bd8cbb8a5512cbb;


public class Pickup
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("FotoCel.Pickup, FotoCel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Pickup.class, __md_methods);
	}


	public Pickup ()
	{
		super ();
		if (getClass () == Pickup.class)
			mono.android.TypeManager.Activate ("FotoCel.Pickup, FotoCel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
