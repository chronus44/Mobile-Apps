package md54c256ff4ed22e8cb20eeb4a2b4f8a8de;


public class CalendarAdapter_VH
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("HM.Source.calendar.CalendarAdapter+VH, HM", CalendarAdapter_VH.class, __md_methods);
	}


	public CalendarAdapter_VH (android.view.View p0)
	{
		super (p0);
		if (getClass () == CalendarAdapter_VH.class)
			mono.android.TypeManager.Activate ("HM.Source.calendar.CalendarAdapter+VH, HM", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
