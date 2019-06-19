//WORKING VERSION

module Pacman

// C:/Users/Michail/OneDrive/Laptop/Imperial_Year_4/FYIP/pacman

//open Fable.Core
open Fable.Core.JsInterop
open Browser.Types
open Browser


module Images =
    (**
    The following block embeds the ghosts and other parts of graphics as Base64 encoded strings.
    This way, we can load them without making additional server requests:
    *)
    let cyand = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAiUlEQVQoU8WSURKAIAhE8Sh6Fc/tVfQoJdqiMDTVV4wfufAAmw3kxEHUz4pA1I8OJVjAKZZ6+XiC0ATTB/gW2mEFtlpHLqaktrQ6TxUQSRCAPX2AWPMLyM0VmPOcV8palxt6uoAMpDjfWJt+o6cr0DPDnfYjyL94NwIcYjXcR/FuYklcxrZ3OO0Ep4dJ/3dR5jcAAAAASUVORK5CYII="
    let oranged = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAgklEQVQoU8WS0RGAIAxDZRRYhblZBUZBsBSaUk/9kj9CXlru4g7r1FxBdsFpGwoa2NwrYIFPEIeM6QS+hQQMYC70EjzuuOlt6gT5kRGGTf0Cx5qfwJYOYIw0L6W1bg+09Al2wAcCS8Y/WjqAZhluxD/B3ghZBO6n1sadzLLEbNSg8pzXIVLvbNvPwAAAAABJRU5ErkJggg=="
    let pinkd = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAj0lEQVQoU8WSsRWAIAxEZRQpXITGVZzIVWxYxAJHwRfwMInxqZV0XPIvgXeuM05eUuayG73TbULQwKWZGTTwCYIJphfwLcRhAW5DLfWrXFLrNLWBKAIBbOkFxJpfQDIXYAh1XoznumRo6Q0kwE8VTLN8o6UL0ArDnfYjSF/Mg4CEaA330sxD3ApHLvUdSdsBdgNkr9L8gxYAAAAASUVORK5CYII="
    let redd = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAkklEQVQoU8WSvRWAIAyEZRQtXIRCV3EiVtGCRSx0FHxBD5MYn1pJl0u+/PDOVcZLY5e47PrJ6TIhaOBSzBoU8AlCE0zP4FuIwwJc25Bz9TyILbVOUwuIJAjAlp5BrPkFpOYC9H6fF+O5LjW09AIS0Az7jUuQN1q6AC0z3Gk/gvTF3AhwiNYQ52Ju4pI4fKljOG0DA3tp97vN6C8AAAAASUVORK5CYII="
    let pu1 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAWElEQVQoU62SUQoAIAhD9f6HNiYYolYi9VfzuXIxDRYbI0LCTHsfe3ldi3BgRRUY9Rnku1Rupf4NgiPeVjVU7STckphBceSvrHHtNPI21HWz4NO3eUUAgwVpmjX/zwK8KQAAAABJRU5ErkJggg=="
    let pu2 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAW0lEQVQoU8WSwQoAIAhD9f8/2lIwdKRIl7o1e010THBESJiJXca76qnoDxFC3SD9LRpWkLnsLt4gdImtlLX/EK4iDapqr4VuI2+BauQjaOrmSz8xillDp5gQrS054jv/0fkNVAAAAABJRU5ErkJggg=="
    let pd1 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAXElEQVQoU62SUQoAIAhD9f6HNgyMWpMs6k/XU5mqwDMTw5yq6JwbAfucwR2qAFHAu75BN11Gt6+Qz54VpMJsMV3BaS9UR8txkUzfLC9DUY0BYbOPGfpyU3g2WdwAOvU1/9KZsT4AAAAASUVORK5CYII="
    let pd2 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAU0lEQVQoU62SUQoAIAhD9f6HNgwUGw4s6q/pc6KqwDMTQ01VtGr56ZIZvKEJEAXc9Q26cUm3r5D3zgrywHeoG3ldJrZIRz6C0I1BoR83FTBCeHsLIlw7/wOkQycAAAAASUVORK5CYII="
    let pl1 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAVUlEQVQoU62S2woAIAhD9f8/2jAwvGRMyDfF49iQKZUISZ4xE/vZaW7LHbwhBLADqjpSUjBAdglRDQa9hxfcQi+vf5RGnpDlkB4KlMgR0N6pBIH83gIPFCb/N+MLCwAAAABJRU5ErkJggg=="
    let pl2 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAUklEQVQoU52SUQoAIAhD3f0PbRQoZgnT/hyttYeQdFRFswYIoubD73JlPibGYA/s1Jmpk+JpDIinWxbiXP3iQslCwbhTxzhHbsWZNFsnCkTevQW2bCb/VRTuVwAAAABJRU5ErkJggg=="
    let pr1 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAWElEQVQoU52S4Q4AIASE3fs/tKalSTHyL/O5CyAXzMQ+BxBsbj9exRE8oQqgDUS1BalNVFSuP2WQL94WIygCBEzttZWOvbz2VBnGtLXg1sgV/L8I679yewN9sScO5wcxLQAAAABJRU5ErkJggg=="
    let pr2 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA0AAAANCAYAAABy6+R8AAAAVElEQVQoU62SWwoAIAgE9f6HNgqU3BK2R3+J48KoCjwzMaypis61+OyaK3hADOADeuoddJISaQy0iKggbEz2viah7mVPTNq7cp/ApLmcdFPVdaDJBnWdJwjk629HAAAAAElFTkSuQmCC"
    let blue = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAeklEQVQoU62S0Q3AIAhEyyi6UcfoRB2jG+koNkeCoVcaTaw/huMeEkS24KTUmpdrFWHbQ2CAzb5AB0eQFTFYwVnIw/+B5by0cD52vTmGhnaF25wBAb/A6HsibR0ctch5fRHi1zCigvCut4oR+wnbhrBmsZr9DlqCQfbcnfZjDyiZqCEAAAAASUVORK5CYII="
    let eyed = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAUElEQVQoU2NkIBMwkqmPYYA13rt37z/I6UpKSiguwSYOVwCThPkZphmXOHU0OjtD7Nu7F+FckI3YxFH8oqgI8eP9+6h+xCY+wNFBSiqiv1MBDgYsD185vj8AAAAASUVORK5CYII="
    let _200 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAS0lEQVQoU2NkIBMwkqmPYYA0vpVR+Q9zsvCTO4yE+CC1KE4FaYBpxEfDNWKzgWiNIIUw5xKyGa+N+PyM4UdS4nSA4pEUJ8LUku1UAMC0VA8iscBNAAAAAElFTkSuQmCC"
    let _400 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAASElEQVQoU2NkIBMwkqmPYYA0vpVR+S/85A4jMg3zAkwcmQ9ig52KTSO6Qch8FI3oNhClEaaJWJvhNmLTSJQfyYnLAYpHujoVAChTXA9pVJi5AAAAAElFTkSuQmCC"
    let _800 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAQElEQVQoU2NkIBMwkqmPYYA0vpVR+Q9zsvCTO4yE+CC1YKeCFMI0EEOjaES3EZ8BtLERn5/hNpITlwMUj3R1KgCe5lwPHtUmcwAAAABJRU5ErkJggg=="
    let _1600 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAQ0lEQVQoU2NkIBMwkqmPYQA0vpVR+S/85A4jiIY5mxg+WANMIYiGaUYXR+ejaES3EdlAvBrxKSTJRnx+HoDoGDopBwDHLGwPAhDgRQAAAABJRU5ErkJggg=="

    // Create image using the specified data
    let createImage data =
      let img = document.createElement("img") :?> HTMLImageElement
      img.src <- data
      img

    // Load the different Pacman images
    let private pu1Img, pu2Img =
      createImage pu1, createImage  pu2
    let private pd1Img, pd2Img =
      createImage pd1, createImage  pd2
    let private pl1Img, pl2Img =
      createImage pl1, createImage pl2
    let private pr1Img, pr2Img =
      createImage pr1, createImage pr2

    // Represent Pacman's mouth state
    let private lastp = ref pr1Img

    
    ///This function returns the pacman image for the specified X and Y location, taking into account the
    ///direction in which Pacman is going. It keeps a mutable state with current step of Pacman's
    ///mouth.
    
    let imageAt(x,y,v) =
      let p1, p2 =
        match !v with
        | -1,  0 -> pl1Img, pl2Img
        |  1,  0 -> pr1Img, pr2Img
        |  0, -1 -> pu1Img, pu2Img
        |  0,  1 -> pd1Img, pd2Img
        |  _,  _ -> !lastp, !lastp
      let x' = int (floor(float (!x/6)))
      let y' = int (floor(float (!y/6)))
      let p = if (x' + y') % 2 = 0 then p1 else p2
      lastp := p
      p

module Keyboard =

    /// Set of currently pressed keys
    let mutable keysPressed = Set.empty
    /// Update the keys as requested
    let reset () = keysPressed <- Set.empty
    let isPressed keyCode = Set.contains keyCode keysPressed

    /// Triggered when key is pressed/released
    let update (e : KeyboardEvent, pressed) =
      let keyCode = int e.keyCode
      let op =  if pressed then Set.add else Set.remove
      keysPressed <- op keyCode keysPressed

    /// Register DOM event handlers
    let init () =
      window.addEventListener("keydown", fun e -> update(e :?> _, true))
      window.addEventListener("keyup", fun e -> update(e :?> _, false))

module Types =
    (**
    Creating ghosts
    ===============
    Ghosts are represented by a simple F# class type that contains the image of the ghost,
    current X, Y positions and a velocity in both directions. In Pacman, ghosts are mutable
    and expose `Move` and `Reset` methods that change their properties.
    *)

    /// Perform 1 iteration of movement (next state)
    /// and warp around maze sides
    /// if at maze cliffs
    let wrap (x,y) (dx,dy) =
      let x =
        if dx = -1 && x = 0 then 30 * 8
        elif dx = 1  && x = 30 *8 then 0
        else x
      x + dx, y + dy

    /// Ghost Class
    /// Mutable representation of a ghost
    type Ghost(image: HTMLImageElement,x,y,v,id) =
      let mutable x' = x
      let mutable y' = y
      let mutable v' = v
      let mutable id' = id
      member val Image = image
      member val IsReturning = false with get, set
      member __.X = x'
      member __.Y = y'
      member __.V = v'
      member __.ID = id'
      member __.Opinion =[|0;0;0;0;0|]
      /// Move back to initial location
      member __.Reset() =
        x' <- x
        y' <- y
      /// Move in the current direction
      member __.Move(v) =
        v' <- v
        let dx,dy = v
        let x,y = wrap (x',y') (dx,dy)
        x' <- x
        y' <- y
      member __.Identify(id) =
        id' <- id


open Images
open Types

(**
Here we define the maze, tile bits and blank block. The maze is defined as one big string
using ASCII-art encoding. Where `/`, `7`, `L` and `J` represent corners (upper-left, upper-right,
lower-left and lower-right), `!`, `|`, `-` and `_` represent walls (left, right, top, bottom) while
`o` and `.` represent two kinds of pills in the maze.
*)

let maze =
 [| "##/------------7/------------7##"
    "##|............|!............|##"
    "##|./__7./___7.|!./___7./__7.|##"
    "##|o|  !.|   !.|!.|   !.|  !o|##"
    "##|.L--J.L---J.LJ.L---J.L--J.|##"
    "##|..........................|##"
    "##|./__7./7./______7./7./__7.|##"
    "##|.L--J.|!.L--7/--J.|!.L--J.|##"
    "##|......|!....|!....|!......|##"
    "##L____7.|L__7 |! /__J!./____J##"
    "#######!.|/--J LJ L--7!.|#######"
    "#######!.|!          |!.|#######"
    "#######!.|! /__==__7 |!.|#######"
    "-------J.LJ |      ! LJ.L-------"
    "########.   | **** !   .########"
    "_______7./7 |      ! /7./_______"
    "#######!.|! L______J |!.|#######"
    "#######!.|!          |!.|#######"
    "#######!.|! /______7 |!.|#######"
    "##/----J.LJ L--7/--J LJ.L----7##"
    "##|............|!............|##"
    "##|./__7./___7.|!./___7./__7.|##"
    "##|.L-7!.L---J.LJ.L---J.|/-J.|##"
    "##|o..|!.......<>.......|!..o|##"
    "##L_7.|!./7./______7./7.|!./_J##"
    "##/-J.LJ.|!.L--7/--J.|!.LJ.L-7##"
    "##|......|!....|!....|!......|##"
    "##|./____JL__7.|!./__JL____7.|##"
    "##|.L--------J.LJ.L--------J.|##"
    "##|..........................|##"
    "##L--------------------------J##" |]

let tileBits =
 [| [|0b00000000;0b00000000;0b00000000;
      0b00000000;0b00000011;0b00000100;
      0b00001000;0b00001000|]

    [|0b00000000;0b00000000;0b00000000;0b00000000;0b11111111;0b00000000;0b00000000;0b00000000|] // top
    [|0b00000000;0b00000000;0b00000000;0b00000000;0b11000000;0b00100000;0b00010000;0b00010000|] // tr
    [|0b00001000;0b00001000;0b00001000;0b00001000;0b00001000;0b00001000;0b00001000;0b00001000|] // left
    [|0b00010000;0b00010000;0b00010000;0b00010000;0b00010000;0b00010000;0b00010000;0b00010000|] // right
    [|0b00001000;0b00001000;0b00000100;0b00000011;0b00000000;0b00000000;0b00000000;0b00000000|] // bl
    [|0b00000000;0b00000000;0b00000000;0b11111111;0b00000000;0b00000000;0b00000000;0b00000000|] // bottom
    [|0b00010000;0b00010000;0b00100000;0b11000000;0b00000000;0b00000000;0b00000000;0b00000000|] // br
    [|0b00000000;0b00000000;0b00000000;0b00000000;0b11111111;0b00000000;0b00000000;0b00000000|] // door
    [|0b00000000;0b00000000;0b00000000;0b00011000;0b00011000;0b00000000;0b00000000;0b00000000|] // pill
    [|0b00000000;0b00011000;0b00111100;0b01111110;0b01111110;0b00111100;0b00011000;0b00000000|] // power
 |]

let blank =
  [| 0b00000000;0b00000000;0b00000000; 0b00000000;0b00000000;0b00000000;0b00000000;0b00000000 |]

(**
Check for walls - FUNCTIONAL:
The following functions parse the maze representation and check various properties of the maze.
Those are used for rendering, but also for checking whether Pacman can go in a given direction.
Characters _|!/7LJ represent different walls
*)

let isWall (c:char) =
  "_|!/7LJ-".IndexOf(c) <> -1

/// Returns ' ' for positions outside of range
let tileAt (x,y) =
  if x < 0 || x > 30 then ' ' else maze.[y].[x]

/// Is the maze tile at x,y a wall?
let isWallAt (x,y) =
  tileAt(x,y) |> isWall

let isGate (c:char) =
    "=".IndexOf(c) <> -1

let isGateAt (x,y) =
    tileAt(x,y) |> isGate


// Is Pacman at a point where it can turn?
let verticallyAligned (x,y) =  (x % 8) = 5
let horizontallyAligned (x,y) = (y % 8) = 5
let isAligned n = (n % 8) = 5

// Check whether Pacman can go in given direction
let noWall (x,y) (ex,ey) =
  let bx, by = (x+6+ex) >>> 3, (y+6+ey) >>> 3
  isWallAt (bx,by) |> not

//let noGate (x,y) (ex,ey) =
//  let bx, by = (x+6+ex) >>> 3, (y+6+ey) >>> 3
//  isGateAt (bx,by) |> not

let canGoUp (x,y) = isAligned x && noWall (x,y) (0,-4)
let canGoDown (x,y) = isAligned x && noWall (x,y) (0,5)
let canGoLeft (x,y) = isAligned y && noWall (x,y) (-4,0)
let canGoRight (x,y) = isAligned y && noWall (x,y) (5,0)

(**
Background rendering - GRAPHICAL
================================
To render the background, we first fill the background
and then iterate over the string lines that represent the maze and we draw images of
walls specified in the `tileBits` value earlier (or use `blank` tile for all other characters).

The following is used to map from tile characters to the `tileBits` values and to draw individual lines:
*)
let tileColors = "BBBBBBBBBYY"
let tileChars =  "/_7|!L-J=.o"

/// Returns tile for a given Maze character
let toTile (c:char) =
  let i = tileChars.IndexOf(c)
  if i = -1 then blank, 'B'
  else tileBits.[i], tileColors.[i]

/// Draw the lines specified by a wall tile
let draw f (lines:int[]) =
  let width = 8
  lines |> Array.iteri (fun y line ->
    for x = 0 to width-1 do
      let bit = (1 <<< (width - 1 - x))
      let pattern = line &&& bit
      if pattern <> 0 then f (x,y) )

/// Creates a brush for rendering the given RGBA color
let createBrush (context:CanvasRenderingContext2D) (r,g,b,a) =
  let id = context.createImageData(1.0, 1.0)
  let d = id.data
  d.[0] <- r; d.[1] <- g
  d.[2] <- b; d.[3] <- a
  id

(**
--GRAPHICAL--
The main function for rendering background just fills the canvas with a black color and
then iterates over the maze tiles and renders individual walls:
*)
let createBackground () =
  // Fill background with black
  let background = document.createElement("canvas") :?> HTMLCanvasElement
  background.width <- 256.
  background.height <- 256.
  let context = background.getContext_2d()
  context.fillStyle <- !^ "rgb(0,0,0)"
  context.fillRect (0., 0. , 256., 256.);

  // Render individual tiles of the maze
  let blue = createBrush context (63uy, 63uy, 255uy, 255uy)
  let yellow = createBrush context (255uy, 255uy, 0uy, 255uy)
  let lines = maze
  for y = 0 to lines.Length-1 do
    let line = lines.[y]
    for x = 0 to line.Length-1 do
      let c = line.[x]
      let tile, color = toTile c
      let brush = match color with 'Y' -> yellow | _ -> blue
      let f (x',y') =
        context.putImageData
          (brush, float (x*8 + x'), float (y*8 + y'))
      draw f tile
  background

/// Clear whatever is rendered in the specified Maze cell
let clearCell (background : HTMLCanvasElement) (x,y) =
  let context = background.getContext_2d()
  context.fillStyle <- !^ "rgb(0,0,0)"
  context.fillRect (float (x*8), float (y*8), 8., 8.)

let createGhosts () =
  [| Images.redd, (16, 11), (1,0)
     Images.cyand, (14, 15), (1,0)
     Images.pinkd, (16, 13), (0,-1)
     Images.oranged, (18, 15), (-1,0) |]
  |> Array.map (fun (data,(x,y),v) ->
        Ghost(Images.createImage data, (x*8)-7, (y*8)-3, v,0) )

let auxiliary (ghostArr:Ghost[]) (index:int) =
    ghostArr.[index].Identify(index) |> ignore
    ghostArr.[index]
    
///Create 4 instances of createGhosts, i.e. 16 ghosts
let allGhosts =
            let a1 = createGhosts ()
            let a2 = createGhosts ()
            let a3 = Array.append a1 a2 
            let a4 = Array.append a3 a3
            [0..15]
            |> List.toArray
            |> Array.map (auxiliary a4)

(**
Generating Ghost movement - FUNCTIONAL
=========================
For generating Ghost movements, we need an implementation of the [Flood fill algorithm](https://en.wikipedia.org/wiki/Flood_fill),
which we use to generate the shortest path home when Ghosts are returning. The `fillValue` function does this, by starting
at a specified location (which can be one of the directions in which ghosts can go).
*)

/// Recursive flood fill function
let flood canFill fill (x,y) =
  let rec f n = function
    | [] -> ()
    | ps ->
        let ps = ps |> List.filter (fun (x,y) -> canFill (x,y))
        ps |> List.iter (fun (x,y) -> fill (x,y,n))
        ps |> List.collect (fun (x,y) ->
            [(x-1,y);(x+1,y);(x,y-1);(x,y+1)]) |> f (n+1)
  f 0 [(x,y)]

/// Possible routes that take the ghost home
let homeRoute =
  let numbers =
    maze |> Array.map (fun line ->
      line.ToCharArray()
      |> Array.map (fun c -> if isWall c then 999 else -1) )
  let canFill (x:int,y:int) =
    y>=0 && y < (numbers.Length-1) &&
    x>=0 && x < (numbers.[y].Length-1) &&
    numbers.[y].[x] = -1
  let fill (x,y,n) = numbers.[y].[x] <- n
  flood canFill fill (16,15)
  numbers

/// Find the shortest way home from specified location
/// (adjusted by offset in which ghosts start)
let fillValue (x,y) (ex,ey) =
  let bx = int (floor(float ((x+6+ex)/8)))
  let by = int (floor(float ((y+6+ey)/8)))
  homeRoute.[by].[bx]

let fillUp (x,y) = fillValue (x,y) (0,-4)
let fillDown (x,y) = fillValue (x,y) (0,5)
let fillLeft (x,y) = fillValue (x,y) (-4,0)
let fillRight (x,y) = fillValue (x,y) (5,0)

(**
--FUNCTIONAL--
When choosing a direction, ghosts that are returning will go in the direction
that leads them home. Other ghosts generate a list of possible directions (the `directions` array)
and then filter those that are in the direction of Pacman and choose one of the options. If they
are stuck and cannot go in any way, they stay where they are.
*)


///Input: Ghost
///Output: Velocity(dx,dy)
///Function: Chooses direction of Ghost
let chooseDirection (ghost:Ghost) =
  let x,y = ghost.X, ghost.Y
  let dx,dy = ghost.V
  //// Are we facing towards the given point?
  let isBackwards (a,b) =
    (a <> 0 && a = -dx) || (b <> 0 && b = -dy)

  
  // Generate array with possible directions
  let directions =
    [|if canGoLeft(x,y) then yield (-1,0), fillLeft(x,y)
      if canGoDown(x,y) then yield (0,1), fillDown(x,y)
      if canGoRight(x,y) then yield (1,0), fillRight(x,y)
      if canGoUp(x,y) then yield (0,-1), fillUp(x,y) |]

  if ghost.IsReturning then
    // Returning ghosts find the shortest way home
    let xs = directions |> Array.sortBy snd
    let v, n = xs.[0]
    if n = 0 then ghost.IsReturning <- false
    v
  else
  let allDirections =
      [|
        (-1,0) // left
        (0,1) // down
        (1,0) //right
        (0,-1) //up
      |]
  
  /// No rules, pure chaos
  let rule1 (arg1 : (int*int) []) : (int*int) [] =
        allDirections


  /// Filter out the directions of walls
  let rule2 (arg1 : (int*int) []) : (int*int) [] =
        arg1
        |> Array.filter (fun dir -> 
                                match dir with
                                |(-1,0) -> canGoLeft(x,y) 
                                |(0,1) -> canGoDown(x,y)
                                |(1,0) -> canGoRight(x,y)
                                |(0,-1) -> canGoUp(x,y)
                                |_->false
                         )
  ///Filter out the backwards direction
  let rule3 (arg1 : (int*int) []) : (int*int) [] =
        arg1
        |> Array.filter (not << isBackwards)
  
  ///ALlowed directions are only left and right
  let rule4 (_ : (int*int) []) : (int*int) [] = 
      [|
        (-1,0) // left
        (1,0) //right
      |]  
  
  ///ALlowed directions are only up and down
  let rule5 (_ : (int*int) []) : (int*int) [] = 
      [|
        (0,1) // down
        (0,-1) //up
      |]

  let allRules : ((int * int) [] -> (int * int) []) [] =
    [|
    rule1 //No rules, pure chaos
    rule2 //Walls out
    rule3 //Backwards out
    rule4 //left and right only
    rule5 //up and down only
    |]
  
  let currentRule = rule2>>rule3;

  let allowedDir =
    allDirections
    |> currentRule


  if allowedDir.Length = 0 then 0, 0
  elif (dx,dy) = (0,0) then    
        let randomNum = System.Random().NextDouble()
        let i = randomNum * float allDirections.Length
        allDirections.[int (floor i)]
  else
    let randomNum = System.Random().NextDouble()
    let i = randomNum * float allowedDir.Length
    allowedDir.[int (floor i)]

/// Count number of dots in the maze
let countDots () =
  maze |> Array.sumBy (fun line ->
    line.ToCharArray()
    |> Array.sumBy (function '.' -> 1 | 'o' -> 1 | _ -> 0))


(**
## The game play function - MAIN RECURSIVE FUNCTION PROCESS

Most of the Pacman game logic is wrapped in the top-level `playLevel` function. This takes two functions - that are called
when the game completes - and then it initializes the world state and runs in a loop until the end of the game.
The following outlines the structure of the function:

    let playLevel (onLevelCompleted, onGameOver) =
      // (Create canvas, background and ghosts)
      // (Define the Pacman state)
      // (Move ghosts and Pacman)
      // (Detect pills and collisiions)
      // (Rendering everything in the game)
      let rec update () =
        logic ()
        render ()
        if !dotsLeft = 0 then onLevelCompleted()
        elif !energy <= 0 then onGameOver()
        else window.setTimeout(update, 1000. / 60.) |> ignore

      update()

After defining all the helpers, the `update` function runs in a loop (via a timer) until there are no dots
left or until the Pacman is out of energy and then it calls one of the continuations.

In the following 5 sections, we'll look at the 5 blocks of code that define the body of the function.
*)

let playLevel () =
  (**
  --GRAPHICAL--
  ### Create canvas, background and ghosts
  In the first part, the function finds the `<canvas>` element, paints it with black background and
  creates other graphical elements - namely the game background, ghosts and eyes:
  *)
  // Fill the canvas element
  let canvas = document.getElementsByTagName("canvas").[0] :?> HTMLCanvasElement
  canvas.width <- 256.
  canvas.height <- 256.
  let context = canvas.getContext_2d()
  context.fillStyle <- !^ "rgb(0,0,0)"
  context.fillRect (0., 0. , 256., 256.);
  let bonusImages =
    [| createImage Images._200; createImage Images._400;
       createImage Images._800; createImage Images._1600 |]

  // Load images for rendering
  let background = createBackground()

  let ghostPool = allGhosts
  let ghosts = 
        [1..4]
        |> List.toArray
        |> Array.map (fun _ -> let randomNum = System.Random().NextDouble()
                               let j = randomNum * float ghostPool.Length
                               let i = int (floor j)
                               let g = ghostPool.[i]
                               ghostPool
                               |> Array.filter(fun a -> (i<>a.ID))
                               |> ignore
                               g
                              
                      )
  let blue,eyed = createImage Images.blue, createImage Images.eyed
