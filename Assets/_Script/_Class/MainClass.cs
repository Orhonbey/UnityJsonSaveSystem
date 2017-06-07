using System;
using System.Collections.Generic;
/*/////------sunal Orhon Save System------/////
* Save için yazmış olduğum basit Class
*/


[Serializable]
public class MainClass
{

    public string MainClassName;
    public string MainClasslastName;
    public Scoreclass userScore;

}
[Serializable]
public class Scoreclass
{
    public List<float> ScoreClass = new List<float>();
}
