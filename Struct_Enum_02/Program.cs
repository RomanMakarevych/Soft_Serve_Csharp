//--------------- Data Type : 

/*All Types:
    - Value types       : strructures : stack (faster,size limited(~ few MB))
    - reference types   : classes     : heap (slower,mo limited)  
*/

//?.- invoke if object is not null
int? averageMark = null;
string? email = null;
averageMark?.ToString();

// ?? return value if object is null

Console.WriteLine($"User email adresse: {email ?? "no email"} ");

Console.WriteLine();

// -----------  Value Types ---------------
/*
 * 
 * Integer-value types:
byte     | 1 byte (0...255)
short    | 2 bytes 
int      | 4 bytes  
long     | 8 bytes 
 

   Real-value types:
bool | 1 byte
char | 2 bytes

float   | 4  bytes
double  | 8  bytes
decimal | 16 bytes
 */


// ------------- literals

Console.WriteLine($" {4} , type: {4.GetType()}");
Console.WriteLine($" {2.2F} , type: {2.2F.GetType()}");
Console.WriteLine($" {4.5} , type: {4.5.GetType()}");
Console.WriteLine($" {4444L} , type: {4444L.GetType()}");

float koef = 4.5F;
decimal salary = 13005.00M;