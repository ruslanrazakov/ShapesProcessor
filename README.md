# Shapes processor

## Welcome to ShapesProcessor!
This is 2D engine, that allows you:
- to detect collisions between shapes
- to recognize foreground shapes in different shapes list

## 1. Core
Core is class library, created with C# and dotnet 6. It contatins basic primitives like Vector, and two versions of shapes = Circle and Polygon. Feel free to implement your own shapes, using Polygon and Circle! 
For example, ShapesProcessor.UI implements Triangle, Rectangle and Circle, based on ShapesProcessor primitives.

ShapesProcessor lib uses CollisionObject wrapper around abstract Shape to detect Collisions between objects. Collision recognition was released in every shape with Visitor pattern, so Circle can recognize collision with Polygon, and Polygon can detect collision with Circle.

TODO:
In  ShapesProcessor.GetForegroundPolygons() method I used two nested loops, it is O(N^2) complexity, I think, I can change loops with some HashTable (Dictionary, for example), if I will have enough time for optimizations.

## 2. UI
UI is WebAssembly application with C# and JavaScript. It is hosted in GitHub pages, here https://ruslanrazakov.github.io/ShapesProcessor/. There is not so much great UI, but a lot of functions:
- randomizer that creates 20 shapes on canvas
- canvas cleaner
- drawing Triangle
- drawing Circle
- drawing Rectangle
- shapes foregrounds search

I used JavaScript for native canvas interraction, and C# for other simple UI and business logic (static mappers from ShapesProcessorLib geometry shapes to UI shape entities, service for incapsulating ShapesProcessor lib interraction and so on).

## 3. Unit tests
I used nUntit for unit tests. I check shapes creating, number of Edges in new Polygons, shapes intersection logic, and foreground search logic.
## 4. Publish and use
Application was deployed with GitHub pages for demo, you can build it yourself:

`git clone https://github.com/ruslanrazakov/ShapesProcessor.git`

`cd ShapesProcessor.UI`

`dotnet run`

Or publish for hosting:

` dotnet publish ShapesProcessor.UI/ShapesProcessor.UI.csproj --runtime -<YOUR_OS> --self-contained=true`

## 5. TODO
1. No async implementation. Core logic in ShapesProcessor.GetForegroundPolygons() is based on 2 arrays - array of input shapes, and foreground shapes. Foreground shapes array change every iteration, and we dont know, what will happen with a new shape from input (collision or nothing). We will see complete array of foreground shapes after loop finishes, so there cant be intermediate result of foreground shapes. Maybe, there is another and more effective good algorythm to detect collisions between objects, I dont know.
2. No area count of shapes
