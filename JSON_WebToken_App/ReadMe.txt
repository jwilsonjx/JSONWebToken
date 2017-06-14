--------------------------------------------
JSON Web Token API
--------------------------------------------
Last Modified:	6/14/2017
Author:			Jason Wilson
Version:		1.0
--------------------------------------------


[USAGE]

The Token controller GET can be called with basic authentication in order to return a JSON Web Token
Requirement: The credentials passed for basic authentication must be added to the QueryUsers method in the VirtualDatabase Model. 

Once a token is obtained, the Data controller GET can be called with the token included in the header (key name: token).
