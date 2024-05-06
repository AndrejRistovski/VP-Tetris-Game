# Tetris Game

WPF Application by: Andrej Ristovski, Anika Ristevska and Mila Jovanoska

## Documentation

### __Македонски:__

#### Опис на апликацијата:

Апликацијата која ја креиравме како тим е класична игра на Tetris во која играчот треба да позиционира паѓачки блокови во различни бои и форми за да создаде целосни редови, кои потоа се исчистуваат за да се освојат поени.

#### Упатство за користење: 

__Почеток на играта:__ Когa ја започнувате *Тетрис* играта, ќе видите темна површина каде ќе паѓаат блокови од врвот. Користете ги стрелките на тастатурата за да ги движите паѓачките блокови лево или десно. Исто така, можете да ги користите стрелките нагоре/надоле за да ги вртите блоковите.

__Паѓање на блокови:__ „*Тетриминос*“ кои се облици составени од седум видови на блока, кои ќе паѓаат од врвот на екранот. Вашата цел е да ги манипулирате овие паѓачки парчиња за да создадете цели хоризонтални редови без било какви празнини помеѓу нив.

__Креирање на редови:__ Кога ќе успеете да го исполните целиот хоризонтален ред со блокови, тој ред ќе исчезне, а вие ќе освоите поени. Што повеќе редови исчистите, толку повеќе поени ќе освоите.

__Брзина и Тежина:__ Во текот на играта, блоковите ќе паѓаат побрзо, зголемувајќи го предизвикот на самата игра. Внимавајте на следното парче блок кое ќе ви се падне за да можете да ги планирате вашите потези предвреме се со цел да ги исполните редовите ефикасно.

__Крај на играта:__ Играта завршува кога блоковите ќе се натрупаат до врвот на екранот, правејќи невозможно за нови парчиња да влезат. Во овој момент играта завршува и на екран ќе ви биде прикажан бројот на освоени поени.

__Добивање поени:__ Освојувате поени за секој ред кој ќе го исчистите. Што повеќе редови исчистите истовремено, толку повеќе поени ќе добиете. Со текот на играта, ќе освоите повеќе поени за исчистување на повеќе редови бидејќи тежината на играта постепено ќе се зголемува.

__Стратегија:__ За да бидете успешни во Тетрис, ќе треба брзо да мислите и да планирате однапред. Обидете се да креирате простор во вашата структура за да ги сместите следните парчиња и обидете се да исчистите повеќе редови со  секој потег за да ги зголемите вашите поени.

#### Претставување на проблемот:

Главните податоци и функции за играта се чуваат во класа public class `Block` од која пак наследуваат класите:
`public class IBlock`, `public class JBlock`, `public class LBlock`, `public class OBlock`, `public class SBlock`, `public class TBlock` и `public class ZBlock.`

#### *__Класата Block__*

Ова е апстрактна класа која претставува основен блок во играта *Tetris*. Оваа класа има методи за вршење на различни акции како вртење, поместување и поставување на блокови на одредени позиции во играта.

__`Kласата Block:`__ Koja чува податоци за облиците кои ги користи играта.

__`Tiles:`__ Дво-димензионално поле што ги опишува позициите на блокот во 4 различни состојби на ротација.

__`StartOffset:`__ Почетната позиција на блокот.

__`Id:`__ Идентификатор на блокот.

__`rotationState:`__ Чува моменталната состојба на ротација на блокот.

__`Offset:`__ Чува тековната позиција на блокот на играта.

__`TilePositions():`__ Метод за генерирање на позициите на секој тетромино блок.

__`RotateCW()` и `RotateCCW():`__ Методи за ротација на блокот во насока на стрелките на часовникот и против нив.

__`Move():`__ Метод за движење на блокот налево, надесно, горе или долу.

__`Reset():`__ Метод за ресетирање на позицијата и состојбата на ротација на блокот.

Секоја променлива и функција во класата `Block` содржи xml summary таг. Дополнително функциите во оваа класа кои враќаат одредена вредност содржат и returns таг, а оние кои примаат одредени влезни аргументи го содржат param тагот.

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Tetris
    {
        /// <summary>
        /// Abstract base class representing a block in Tetris. Each block has a unique identifier,
        /// a set of possible rotations represented by tile positions, and a starting offset for spawning on the grid.
        /// </summary>

    public abstract class Block
    {
        /// <summary>
        /// Protected abstract property defining the different rotation states of the block.
        /// Each block can have up to four rotation states, each represented by an array of positions.
        /// </summary>

            protected abstract Position[][] Tiles { get; } //Two dimensional possition array which contains the tile positions in the 4 rotation states.

        /// <summary>
        /// Protected abstract property that specifies the starting position of the block when it spawns.
        /// </summary>

            protected abstract Position StartOffset { get; } //Decides  where the block spawns in the grid.

        /// <summary>
        /// Unique identifier for the block, used to distinguish between different block types.
        /// </summary>

            public abstract int Id { get; } // "Id" which we need to destinguish the blocks.

        /// <summary>
        /// Internal state indicating the current rotation of the block.
        /// </summary>

            private int rotationState; // "rotationState" which we need to store the current rotation state of the block.

        /// <summary>
        /// Current offset from the initial position.
        /// </summary>

            private Position offset; // "offset" which we need to store the current offset of the block.

        /// <summary>
        /// Initializes a new instance of the Block class, setting the initial position based on the start offset.
        /// </summary>

    public Block()
    {
            offset = new Position(StartOffset.Row, StartOffset.Column);
    }
        /// <summary>
        /// Enumerates the positions of the tiles based on the current rotation state and position offset.
        /// </summary>

        /// <returns> An enumerable of positions representing the current configuration of the block on the grid.
        /// </returns>

    public IEnumerable&lt<Position&gt> TilePositions()
    {
           foreach(Position position in Tiles[rotationState])
           {
              // The &#39;foreach&#39; continues where we left off.
              // yield return new Position(position.Row + offset.Row, position.Column + offset.Column);
           }
    }
        /// <summary>
        /// Rotates the block 90 degrees clockwise.
        /// <summary>

    //Method which rotates the block 90 degrees clockwise.

    public void RotateCW()
    {
        rotationState = (rotationState + 1) % Tiles.Length;
    }
        /// <summary>
        /// Rotates the block counter-clockwise.
        /// <summary>

    //Methiod which rotates counter-clockwise.

    public void RotateCCW()
    {
       if(rotationState == 0)
       {
          rotationState = Tiles.Length - 1;
       }
       else
       {
          rotationState--;
       }
    }
        /// <summary>
        /// Moves the block by a specified number of rows and columns.
        
        /// </summary>
        /// <param name="rows"> The number of rows to move the block down.</param>
        /// <param name="columns"> The number of columns to move the block sideways.</param>

    // Method which moves the block by a given number of rows and columns.

    public void Move (int rows, int columns)
    {
        offset.Row += rows;
        offset.Column += columns;
    }

        /// <summary>
        /// Resets the block to its initial position and rotation state.
        /// </summary>

    //Method which resets the rotation and position.

    public void Reset()
    {
        rotationState = 0;
        offset.Row = StartOffset.Row;
        offset.Column = StartOffset.Column;
    }
     }
    }

#### *__Класа BlockQueue__*

Оваа класа се грижи за креирање на редица од блокови кои ќе се користат вo играта. Генерирањето на блокови е случајно, но се гарантира дека последователните блокови во редицата не се исти. Чува листа од сите можни блокови (тетромина) во играта.

__`blocks:`__ Низа од објекти од класата Block, што претставуваат сите можни типови на блокови.

__`random:`__ Генератор на случајни броеви за избирање на следниот блок.

__`NextBlock:`__ Пред-избраниот блок за следното движење во играта.

__`RandomBlock():`__ Метод за избор на случаен блок од листата на блокови.

__`GetAndUpdate():`__ Метод за добивање на следниот блок за игра и ажурирање на NextBlock.

#### *__Класа GameGrid__*

Оваа класа го претставува игралното поле во Tetris. Се чуваат информации за состојбата на секоја позиција во полето, како и методи за проверка дали дадена позиција е празна или дали цел ред е полн. Чува податоци за мрежата на играта (игралното поле).

__`grid:`__ Дво-димензионална матрица што ги претставува полињата на игралното поле.

__`Rows и Columns:`__ Големината на мрежата (број на редици и колони).

__`IsInside():`__ Метод за проверка дали дадена позиција е внатре во границите на мрежата.

__`IsEmpty():`__ Метод за проверка дали дадена позиција е празна.

__`IsRowFull():`__ Метод за проверка дали дадена редица е целосно исполнета со блокови.

__`IsRowEmpty():`__ Метод за проверка дали дадена редица е целосно празна.

__`ClearRow():`__ Метод за бришење на содржината на дадена редица.

__`MoveRownDown():`__ Метод за преместување на содржината на една редица надолу.

__`ClearFullRows():`__ Метод за бришење на сите целосно исполнети редици и преместување на горните редици надолу.

#### *__Класа GameState__*

Оваа класа го чува моменталното состојба на играта. Се чуваат информации за:
- Моменталниот блок кој играчот го манипулира игралното поле
- Редицата со следни блокови кои ќе се користат податоци за поени, дали играта завршила и сл. Оваа класа ги содржи методите за манипулирање на состојбата на играта, како и методи за проверка на колизии и поместување на блокови.

#### *__Класа Position__*

Оваа класа го претставува положбата на блок во играта Tetris. Секоја инстанца на класата има два атрибути:
 - Row (редица): го претставува редицата на која се наоѓа блокот.
 - Column (колона): го претставува столбот на кој се наоѓа блокот. Конструкторот на класата има за цел да ги иницијализира овие атрибути со дадени вредности за редицата и колоната.

#### __Класите за конкретните блокови (IBlock, JBlock, LBlock, OBlock, SBlock, TBlock, ZBlock)__

Секоја од овие класи го претставува еден од можните блокови во
играта Tetris. Во секоја од класите, се чуваат информации за:
 - Позициите на тиловите на блокот (tiles)
 - Идентификацискиот број на блокот (Id)
 - Почетната позиција на блокот (StartOffset)
 - Логиката за поместување, вртење и проверка на блокот дали може да се стави на одредена позиција во играта

### __Englsih:__

#### Description:
The application we created as a team is a classic Tetris game where the player needs to position falling blocks of different colors and shapes to create complete rows, which are then cleared to earn points.

#### Usage Instructions:
__Starting the Game:__ When you start the *Tetris* game, you'll see a dark area where blocks will fall from the top. Use the arrow keys on the keyboard to move the falling blocks left or right. Also, you can use the up/down arrow keys to rotate the blocks.

__Falling Blocks:__ "Tetriminos" are shapes composed of seven types of blocks that will fall from the top of the screen. Your goal is to manipulate these falling pieces to create complete horizontal rows without any gaps between them.

__Creating Rows:__ When you manage to fill an entire horizontal row with blocks, that row will disappear, and you will earn points. The more rows you clear, the more points you'll earn.

__Speed and Difficulty:__ During the game, the blocks will fall faster, increasing the challenge of the game. Pay attention to the next block piece that will fall to plan your moves in advance to efficiently clear the rows.

__End of Game:__ The game ends when the blocks pile up to the top of the screen, making it impossible for new pieces to enter. At this point, the game ends, and the number of points earned will be displayed on the screen.

__Scoring Points:__ You earn points for each row you clear. The more rows you clear simultaneously, the more points you'll get. As the game progresses, you'll earn more points for clearing multiple rows because the game's difficulty gradually increases.

__Strategy:__ To be successful in Tetris, you'll need to think quickly and plan ahead. Try to create space in your structure to accommodate the next pieces and aim to clear more rows with each move to increase your points.

#### Problem Representation:

The main data and functions for the game are stored in the class `Block`, from which the classes inherit:
`public class IBlock`, `public class JBlock`, `public class LBlock`,
`public class OBlock`, `public class SBlock`, `public class TBlock`, and
`public class ZBlock`.

#### *__Block Class__*

This is an abstract class representing a basic block in the *Tetris* game. This class has methods for performing various actions such as rotating, moving, and placing blocks at specific positions in the game.

__`Block Class:`__ Stores data about the tiles used by the game.

__`Tiles`:__ A two-dimensional array describing the positions of the block in 4 different rotation states.

__`StartOffset`:__ The initial position of the block.

__`Id`:__ Identifier of the block.

__`rotationState`:__ Stores the current rotation state of the block.

__`Offset`:__ Stores the current position of the block in the game.

__`TilePositions()`:__ Method for generating the positions of each tetromino block.

__`RotateCW()` and `RotateCCW()`:__ Methods for rotating the block clockwise and counterclockwise.

__`Move()`:__ Method for moving the block left, right, up, or down.

__`Reset()`:__ Method for resetting the position and rotation state of the block.

Each variable and function in the `Block` class contains an xml summary tag. Additionally, functions in this class that return a specific value also contain a returns tag, and those that take specific input arguments contain a param tag.

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Tetris
    {
        /// <summary>
        /// Abstract base class representing a block in Tetris. Each block has a unique identifier,
        /// a set of possible rotations represented by tile positions, and a starting offset for spawning on the grid.
        /// </summary>

    public abstract class Block
    {
        /// <summary>
        /// Protected abstract property defining the different rotation states of the block.
        /// Each block can have up to four rotation states, each represented by an array of positions.
        /// </summary>

            protected abstract Position[][] Tiles { get; } //Two dimensional possition array which contains the tile positions in the 4 rotation states.

        /// <summary>
        /// Protected abstract property that specifies the starting position of the block when it spawns.
        /// </summary>

            protected abstract Position StartOffset { get; } //Decides  where the block spawns in the grid.

        /// <summary>
        /// Unique identifier for the block, used to distinguish between different block types.
        /// </summary>

            public abstract int Id { get; } // "Id" which we need to destinguish the blocks.

        /// <summary>
        /// Internal state indicating the current rotation of the block.
        /// </summary>

            private int rotationState; // "rotationState" which we need to store the current rotation state of the block.

        /// <summary>
        /// Current offset from the initial position.
        /// </summary>

            private Position offset; // "offset" which we need to store the current offset of the block.

        /// <summary>
        /// Initializes a new instance of the Block class, setting the initial position based on the start offset.
        /// </summary>

    public Block()
    {
            offset = new Position(StartOffset.Row, StartOffset.Column);
    }
        /// <summary>
        /// Enumerates the positions of the tiles based on the current rotation state and position offset.
        /// </summary>

        /// <returns> An enumerable of positions representing the current configuration of the block on the grid.
        /// </returns>

    public IEnumerable&lt<Position&gt> TilePositions()
    {
           foreach(Position position in Tiles[rotationState])
           {
              // The &#39;foreach&#39; continues where we left off.
              // yield return new Position(position.Row + offset.Row, position.Column + offset.Column);
           }
    }
        /// <summary>
        /// Rotates the block 90 degrees clockwise.
        /// <summary>

    //Method which rotates the block 90 degrees clockwise.

    public void RotateCW()
    {
        rotationState = (rotationState + 1) % Tiles.Length;
    }
        /// <summary>
        /// Rotates the block counter-clockwise.
        /// <summary>

    //Methiod which rotates counter-clockwise.

    public void RotateCCW()
    {
       if(rotationState == 0)
       {
          rotationState = Tiles.Length - 1;
       }
       else
       {
          rotationState--;
       }
    }
        /// <summary>
        /// Moves the block by a specified number of rows and columns.
        
        /// </summary>
        /// <param name="rows"> The number of rows to move the block down.</param>
        /// <param name="columns"> The number of columns to move the block sideways.</param>

    // Method which moves the block by a given number of rows and columns.

    public void Move (int rows, int columns)
    {
        offset.Row += rows;
        offset.Column += columns;
    }

        /// <summary>
        /// Resets the block to its initial position and rotation state.
        /// </summary>

    //Method which resets the rotation and position.

    public void Reset()
    {
        rotationState = 0;
        offset.Row = StartOffset.Row;
        offset.Column = StartOffset.Column;
    }
     }
    }

#### *__Class BlockQueue__*

This class is responsible for creating a queue of blocks to be used in the game. Block generation is random, but it is guaranteed that consecutive blocks in the queue are not the same. It keeps a list of all possible blocks (tetrominos) in the game.

__`blocks:`__ Array of objects of the Block class, representing all possible types of blocks.

__`random:`__ Random number generator for selecting the next block.

__`NextBlock:`__ The pre-selected block for the next move in the game.

__`RandomBlock():`__ Method for selecting a random block from the block list.

__`GetAndUpdate():`__ Method for getting the next block for the game and updating NextBlock.

#### *__Class GameGrid__*

This class represents the playing field in Tetris. Information about the state of each position in the field is stored, as well as methods for checking if a given position is empty or if a whole row is full. It holds data about the game grid (playing field).

__`grid:`__ Two-dimensional matrix representing the fields of the game grid.

__`Rows and Columns:`__ The size of the grid (number of rows and columns).

__`IsInside():`__ Method for checking if a given position is inside the grid boundaries.

__`IsEmpty():`__ Method for checking if a given position is empty.

__`IsRowFull():`__ Method for checking if a given row is completely filled with blocks.

__`IsRowEmpty():`__ Method for checking if a given row is completely empty.

__`ClearRow():`__ Method for clearing the contents of a given row.

__`MoveRowDown():`__ Method for moving the contents of a row down.

__`ClearFullRows():`__ Method for clearing all completely filled rows and moving the upper rows down.

#### *__Class GameState__*

This class stores the current state of the game. It holds information about:
- The current block being manipulated by the player
- The queue of next blocks to be used
- Data for points, whether the game has ended, etc.
This class contains methods for manipulating the game state, as well as methods for collision checking and block movement.

#### *__Class Position__*

This class represents the position of a block in the Tetris game. Each instance of the class has two attributes:
 - Row: Represents the row on which the block is located.
 - Column: Represents the column in which the block is located.
The constructor of the class aims to initialize these attributes with given values for the row and column.

#### *__Classes for Specific Blocks (IBlock, JBlock, LBlock, OBlock, SBlock, TBlock, ZBlock)__*

Each of these classes represents one of the possible blocks in the Tetris game. In each class, information about:
 - The positions of the block's tiles (tiles)
 - The identification number of the block (Id)
 - The starting position of the block (StartOffset)
 - The logic for moving, rotating, and checking if the block can be placed at a certain position in the game, is stored.
