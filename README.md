[README.md](https://github.com/AndrejRistovski/VP-Tetris-Game/files/15214239/README.md)
# Tetris Game

WPF Application by: Andrej Ristovski, Anika Ristevska and Mila Jovanoska

## Documentation
#### __Македонски:__
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

Главните податоци и функции за играта се чуваат во класа public class *__Block__* од која пак наследуваат класите:
*public class IBlock, public class JBlock, public class LBlock,
public class OBlock, public class SBlock, public class TBlock и
public class ZBlock.*

#### *__Класата Block__*

Ова е апстрактна класа која претставува основен блок во играта *Tetris*. Оваа класа има методи за вршење на различни акции како вртење, поместување и поставување на блокови на одредени позиции во играта.

__Kласата Block:__ Koja чува податоци за облиците кои ги користи играта.

__Tiles:__ Дво-димензионално поле што ги опишува позициите на блокот во 4 различни состојби на ротација.

__StartOffset:__ Почетната позиција на блокот.

__Id:__ Идентификатор на блокот.

__rotationState:__ Чува моменталната состојба на ротација на блокот.

__Offset:__ Чува тековната позиција на блокот на играта.

__TilePositions():__ Метод за генерирање на позициите на секој тетромино блок.

__RotateCW() и RotateCCW():__ Методи за ротација на блокот во насока на стрелките на часовникот и против нив.

__Move():__ Метод за движење на блокот налево, надесно, горе или долу.

__Reset():__ Метод за ресетирање на позицијата и состојбата на ротација на блокот.

Секоја променлива и функција во класата Block содржи xml summary таг. Дополнително функциите во оваа класа кои враќаат одредена вредност содржат и returns таг, а оние кои примаат одредени влезни аргументи го содржат param тагот.

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

__blocks:__ Низа од објекти од класата Block, што претставуваат сите можни типови на блокови.

__random:__ Генератор на случајни броеви за избирање на следниот блок.

__NextBlock:__ Пред-избраниот блок за следното движење во играта.

__RandomBlock():__ Метод за избор на случаен блок од листата на блокови.

__GetAndUpdate():__ Метод за добивање на следниот блок за игра и ажурирање на NextBlock.

#### *__Класа GameGrid__*

Оваа класа го претставува игралното поле во Tetris. Се чуваат информации за состојбата на секоја позиција во полето, како и методи за проверка дали дадена позиција е празна или дали цел ред е полн. Чува податоци за мрежата на играта (игралното поле).

__grid:__ Дво-димензионална матрица што ги претставува полињата на игралното поле.

__Rows и Columns:__ Големината на мрежата (број на редици и колони).

__IsInside():__ Метод за проверка дали дадена позиција е внатре во границите на мрежата.

__IsEmpty():__ Метод за проверка дали дадена позиција е празна.

__IsRowFull():__ Метод за проверка дали дадена редица е целосно исполнета со блокови.

__IsRowEmpty():__ Метод за проверка дали дадена редица е целосно празна.

__ClearRow():__ Метод за бришење на содржината на дадена редица.

__MoveRownDown():__ Метод за преместување на содржината на една редица надолу.

__ClearFullRows():__ Метод за бришење на сите целосно исполнети редици и преместување на горните редици надолу.

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
