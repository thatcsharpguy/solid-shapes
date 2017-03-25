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

## Cumpliendo el SRP  
Para cumplir con el principio, quitamos la funcionalidad de sumatorias de la clase `Rectangle` e introducimos un par de clases encargadas de realizar las operaciones sobre el los conjuntos de rectángulos, su código es más o menos este:  

```
public class AreaOperations
{
    public static double Sum(IEnumerable<Rectangle> rectangles)
    {
        //
        

public class PerimeterOperations
{
    public static double Sum(IEnumerable<Rectangle> rectangles)
    {
        //
```  
Entonces así cada clase tiene una sola responsabilidad: una representa un rectángulo y las otras se encargan de hacer operaciones relacionadas con ellos.  

Ahora, supón que después de cierto tiempo, a la gente le gustó tanto tu programa que te piden que ahora tomes en cuenta también triángulos equiláteros y que tu programa permita sumar las áreas de triángulos con rectángulos.  

Entonces creas una nueva clase para representar los triángulos, y modificas los métodos para sumar áreas  para que estos acepten tanto rectángulos como triángulos y dentro de ellos verificas de qué tipo es cada objeto y realizas el cálculo apropiado: 

```
public class PerimeterOperations
{
    public double Sum(IEnumerable<object> shapes)
    {
        double perimeter = 0;
        foreach (var shape in shapes)
        {
            if (shape is Rectangle)
                perimeter += 2 * ((Rectangle)shape).Height + 2 * ((Rectangle)shape).Width;
            else if (shape is EquilateralTriangle)
                perimeter += ((EquilateralTriangle) shape).SideLength * 3;
        }
        return perimeter;
    }
}

public class AreaOperations
{
    public double Sum(IEnumerable<object> shapes)
    {
        double area = 0;
        foreach (var shape in shapes)
        {
            if(shape is Rectangle)
                area += ((Rectangle)shape).Height * ((Rectangle)shape).Width;
            else if(shape is EquilateralTriangle)
                area += Math.Sqrt(3) *  Math.Pow(((EquilateralTriangle)shape).SideLength,2) / 4;
        }
        return area;
    }
}
```  

Todo parece perfecto nuévamente, tu programa funciona de mil maravillas, pero está violando el principio de abierto/cerrado.  

## Violación del OCP
Probablemente ya tengas una idea de en qué parte del código se está violando este principio... pero si no: en las clases de operaciones, y es que tu programa está abierto a la extensión... pero no a la modificación. Ponte a pensar en qué va a pasar mañana que los círculos se pongan de moda. Tendrías que modificar el código de las operciones para que funcione con otra figura y así para cada figura que se le ocurra a los usuarios de tu programa.   

## Cumpliendo el OCP  
La solución a esta violación se dará mediante el uso de abstracciones (en este caso la interfaz `IGeometricShape`) a través de la cual indicaremos que nuestras figuras comparten propiedades y métodos (en este caso el área y el perímetro):

```
public interface IGeometricShape
{
    double Area();
    double Perimeter();
}
```

Y también tenemos que modificar las clases de operaciones para que acepten ahora objetos que cumplan con ese comportamiento, para así poder llamar a esos métodos, sin tener que preocuparse de qué tipo son "realmente" los objetos con los que está trabajando:  

```
public double Sum(IEnumerable<IGeometricShape> shapes)
{
    double area = 0;
    foreach (var shape in shapes)
        area += shape.Area();
    return area;
}

public double Sum(IEnumerable<IGeometricShape> shapes)
{
    double perimeter = 0;
    foreach (var shape in shapes)
        perimeter += shape.Perimeter();
    return perimeter;
}
```

De este modo para cuando en el futuro agreguémos nuevas figuras, únicamente tendremos que hacer que implementen ese comportamiento en común y no tendremos que modificar el código ya existente.  
