package md507a5ccc0d503142c74d6f404119a6c74;


public class Payment
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.io.Serializable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("HM.Source.payment.Payment, HM", Payment.class, __md_methods);
	}


	public Payment ()
	{
		super ();
		if (getClass () == Payment.class)
			mono.android.TypeManager.Activate ("HM.Source.payment.Payment, HM", "", this, new java.lang.Object[] {  });
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
