Piensa en una aplicación bastante... bastante sencilla que calcula la suma de las áreas y perímetros de un conjunto de rectángulos. Para esto, tienes una clase llamada `Rectangle` que se ve más o menos así:

```
public class Rectangle
{
    public double Sides { get; } = 4;
    public double Height { get; set; }
    public double Width { get; set; }

    public static double SumAreas(IEnumerable<Rectangle> rectangles)
    {
        //   
    }

    public static double SumPerimeters(IEnumerable<Rectangle> rectangles)
    {
        //
    }
}
```

Mientras que el programa principal se encarga de crear los `rectángulos` y llamar a los métodos respectivos para obtener las sumas:

```
var rectangulos = new[]
{
    new Rectangle {Width = 10, Height = 5},
    new Rectangle {Width = 4, Height = 6},
    new Rectangle {Width = 5, Height = 1},
    new Rectangle {Width = 8, Height = 9}
};

var sumaDeAreas = Rectangle.SumAreas(rectangulos);
var sumaDePerimetros = Rectangle.SumPerimeters(rectangulos);
```  

Todo parece perfecto, tu programa funciona de mil maravillas, pero está violando el principio de responsabilidad única.  

## Violación del SRP  
La violación ocurre al momento de declarar los métodos `SumAreas` y `SumPerimeters` dentro de la misma clase que `Rectangle` y es que a pesar de que están relacionadas con el rectángulo como tal, la sumatoria forma parte de nuestra lógica de la aplicación, no de la lógica que podría tener un rectángulo en la vida real.  