<Query Kind="Expression" />

///						  Pliki (te 65 giga)
///								|
///								|
///						+----------------+
///						| TransformBlock | BoundedCapacity=100
///						|  SimpleParse   | MaxDegreeOfParallelism = ProcessorCount*2
///						+----------------+
///								|	
///						+----------------+
///						|  BrodcastBlock |
///						+----------------+
///						/		 		  \
///					   /		 		   \
///					  /			   			\
///					 /	     				 ---------------
///					/		  				  				|
///				   / 		   			       				|
///		+----------------+  				   				|
///		| TransformBlock |BoundedCapacity=50  				|
///		|   Recognise    |MaxDegreeOfParallelism=ProcCount/2|
///		+----------------+MaxMessagesPerTask=1  			|	
///				|											|
///		+----------------+									|
///		|  BrodcastBlock |									|
///		+----------------+							+---------------+
///				|		 \							| TransforBlock | MaxDegreeOfParallelism = 20
///				|		+---------------+			|   GetImages   | BoundedCapacity = 50
///				|		|  ActionBlock	|			+---------------+
///				|		|  SaveToDrive	|					|
///				|		+---------------+			+----------------+
///		        |									| TransformBlock |
///		        |									|     Rescale    |
///		        |        							+----------------+
///				|											|
///				|											|
///				|									+----------------+
///				|									| TransformBlock |
///				|									|   SaveToDrive  |
///				|									+----------------+
///				|					   						/		
///				|		   ---------------------------------			
///				|		 /						
///		+---------------+				
///		|    JoinBock   |
///		+---------------+			
///				|
///				|
///				|
///		+---------------+ 
///		| TransformBlock|
///		|  CreateDbRep  |
///		+---------------+
///				|	     
///				|		 
///		+----------------+ 				+---------------+
///		|  BrodcastBlock |				|   AcionBlock  |
///		+----------------+ ----------->	|   SaveToFile  |
///				|		 				+---------------+
///		+----------------+
///		|  ActionBlock   |
///		| SaveToDatabase | MaxDegreeOfParallelism = 1
///		+----------------+