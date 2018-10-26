package md558bc5bee9a40e13358734af70ba46d33;


public class SearchAdapter_VH
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("HM.Source.search.SearchAdapter+VH, HM", SearchAdapter_VH.class, __md_methods);
	}


	public SearchAdapter_VH (android.view.View p0)
	{
		super (p0);
		if (getClass () == SearchAdapter_VH.class)
			mono.android.TypeManager.Activate ("HM.Source.search.SearchAdapter+VH, HM", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
