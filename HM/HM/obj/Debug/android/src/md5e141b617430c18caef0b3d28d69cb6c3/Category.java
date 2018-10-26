package md5e141b617430c18caef0b3d28d69cb6c3;


public class Category
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
		mono.android.Runtime.register ("HM.Category, HM", Category.class, __md_methods);
	}


	public Category ()
	{
		super ();
		if (getClass () == Category.class)
			mono.android.TypeManager.Activate ("HM.Category, HM", "", this, new java.lang.Object[] {  });
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
