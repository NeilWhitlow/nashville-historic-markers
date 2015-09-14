##Brainstorming##

###MainActivity###

* ####Pass Detail To MarkerActivity In Intent####
Serialize the selected Marker to json, then pass in Intent. 
When we get the selected item from the ListView, it is returned as a Java object. The following post helped me around casting issued to turn that object back into a strongly typed Marker object [Cast Java Lang Object to CLR type](https://forums.xamarin.com/discussion/14863/cannot-cast-single-custom-listview-row-to-its-lists-type)

* ####Cache Data In Json Format####
In case the device does not have a connection, cache the data in simple json format to disk.
 

### MarkerAdapter ###
* [Recycle Views and Use ViewHolder Pattern] (https://blog.xamarin.com/creating-highly-performant-smooth-scrolling-android-listviews/)

###MarkerActivity (detail page)###

* #### Photo ####
Given that the public data store does not include a photo, is it possible to use the coordinates to retrieve the Google streetview in the proper orientation reliably to present a view of where the Marker is at?


* #### Maps ####
On MarkerActivity provide a tab for display of Google Map with a Marker denoting the Marker :)



