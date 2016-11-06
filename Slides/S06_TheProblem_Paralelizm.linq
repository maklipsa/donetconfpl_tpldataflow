<Query Kind="Expression" />

///						+---------------+
///						|     Crawl     | Bardzo dużo czekania, niezależne operacje, bardzo duży potencjał zrównoleglenia
///						+---------------+
///							/		 \
///						   /		  \
///						  /			   \
///		+---------------+				+---------------+
///		|  SimpleParse  | 				|   SaveToDrive |
///		+---------------+				+---------------+
///				|	     \
///				|		   --------------
///				V		   			      \
///		+---------------+  				   +---------------+
///		|   Recognise   |dużo niezależnych |   GetImages   | dużo czekania, bardzo duży potencjał zrównoleglenia
///		+---------------+  obliczeń 	   +---------------+
///				|								|
///				|								|
///				V								V
///		+---------------+				+---------------+
///		|  SaveToDrive  |				|    Rescale    |
///		+---------------+				+---------------+
///				|								|
///				|								|
///				|								V
///				|						+---------------+
///				|						|  SaveToDrive  |
///				|						+---------------+
///				|					   /		
///				|		   ------------			
///				V		 /						
///		+---------------+				
///		|     Combine   |				
///		+---------------+			
///				|								
///				|								
///				V								
///		+---------------+  				+---------------+
///		|  CreateDbRep  | ----------->	|  SaveToFile   |
///		+---------------+				+---------------+
///				|	     
///				|		 
///				V		 
///		+----------------+
///		| SaveToDatabase | Zdecydowanie nie zrównoleglać
///		+----------------+