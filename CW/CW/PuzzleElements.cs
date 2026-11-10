using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Petkunas__Lukas___Byte_size_Quiz
{
    public class Tile
    {
        public char Type { get; set; }
        public Image Sprite { get; set; }
        public bool IsSolid { get; set; }
        public bool IsPushable { get; set; }
        public bool IsRotatable { get; set; }
        public bool IsPartOfBlock { get; set; }
        public PushableBlock Block { get; set; }
        public RotatableGroup RotatableGroup { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        // constructor for normal tile
        public Tile(char type, Image sprite, int newX, int newY)
        {
            Type = type;
            Sprite = sprite;
            IsSolid = (type == 'X' || type == 'B' || type == 'V' || type == 'C') || (type == 'I');  // boxes, walls, cog,  etc. all block movement
            IsPushable = (type == 'B') || (type == 'I');  // only boxes are pushable
            IsRotatable = (type == 'V'); // only the teeth of cogs are rotatable
            IsPartOfBlock = (type == 'B'); // only B type boxes can be amalgamated
            // object used to represent the box group that an individual box is in
            Block = null;

            //object used to represent the cog that a tooth or centre is a part of
            RotatableGroup = null;

            // set the coordinates of the new tile
            X = newX;
            Y = newY;

        }

        // required methods if wanting to compare tiles
        public override bool Equals(object obj)
        {
            if (obj is Tile other)
            {
                // if the tile is in the same place, and is of the same type, it's the same tile
                return this.X == other.X && this.Y == other.Y && this.Type == other.Type;
            }
            return false;
        }

        public override int GetHashCode()
        {
            // combine x, y, and type to create a unique hash code for the Tile object
            int hashX = X.GetHashCode();
            int hashY = Y.GetHashCode();
            int hashType = Type.GetHashCode();
            return hashX ^ hashY ^ hashType; // use xor to combine the hashes
        }

        // constructor used when cloning the entire grid; cannot simply set tiles equal to each other when cloning due to shallow copying
        // clonedBlocks is a dictionary used to store the existing blocks and new corresponding blocks from the old grid
        // cloneRotateGroups is the same but for cogs
        public Tile(Tile other, Dictionary<PushableBlock, PushableBlock> clonedBlocks, Dictionary<RotatableGroup, RotatableGroup> clonedRotateGroups)
        {
            // copy over properties
            Type = other.Type;
            Sprite = other.Sprite;
            IsSolid = other.IsSolid;
            IsPushable = other.IsPushable;
            IsRotatable = other.IsRotatable;
            IsPartOfBlock = other.IsPartOfBlock;
            X = other.X;
            Y = other.Y;

            // if the old tile was a part of a block
            if (other.Block != null)
            {
                // if this block was not already added to the dictionary
                if (!clonedBlocks.ContainsKey(other.Block))
                {
                    // create a new, empty block, then add this newBlock to the dictionary
                    PushableBlock newBlock = new PushableBlock(new List<Tile>());
                    clonedBlocks[other.Block] = newBlock;
                }

                // assign the corresponding new block to the new tile
                Block = clonedBlocks[other.Block];
            }
            else Block = null;

            // if the old tile was a part of a cog
            if (other.RotatableGroup != null)
            {
                // if the cog was not already added to the dctionary
                if (!clonedRotateGroups.ContainsKey(other.RotatableGroup))
                {
                    // create a new cog, then add this cog to the dictionary. as this is a clone, a new centretile need not be made as it will be in the same position, same type, etc.
                    RotatableGroup newGroup = new RotatableGroup(new List<Tile>(), other.RotatableGroup.CentreTile);
                    clonedRotateGroups[other.RotatableGroup] = newGroup;
                }

                // assign the corresponding new cog to the new tile
                RotatableGroup = clonedRotateGroups[other.RotatableGroup];
            }
            else RotatableGroup = null;
        }
    }

    public class RotatableGroup
    {
        // list used to store the tiles belonging to the group
        public List<Tile> VTiles { get; private set; }
        public Tile CentreTile { get; private set; }

        public RotatableGroup(List<Tile> vTiles, Tile centreTile)
        {
            VTiles = vTiles;
            CentreTile = centreTile;
        }

        // method used to find all cogs in the current grid and allocate each cog tile to their respective cogs
        public static List<RotatableGroup> GetRotatableGroups(Tile[,] grid)
        {
            List<RotatableGroup> groups = new List<RotatableGroup>();

            // create a boolean grid to ensure that, when stumbling upon a new tile that neighbours an old one, we do not double count the old one
            bool[,] visited = new bool[grid.GetLength(0), grid.GetLength(1)];

            // -1 as the last line is metadata
            for (int y = 0; y < grid.GetLength(0) - 1; y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    // if we haven't visited the current tile and it's a centre one
                    if (!visited[y, x] && grid[y, x].Type == 'C')  // Look for 'C' tiles
                    {
                        // create a new list of tiles - this will be VTiles
                        List<Tile> currentGroup = new List<Tile>();
                        currentGroup.Add(grid[y, x]);

                        // check each adjacent tile to see if it's a tooth, and if it is, add it to the new list
                        if (grid[y - 1, x].Type == 'V') currentGroup.Add(grid[y - 1, x]);
                        if (grid[y + 1, x].Type == 'V') currentGroup.Add(grid[y + 1, x]);
                        if (grid[y, x - 1].Type == 'V') currentGroup.Add(grid[y, x - 1]);
                        if (grid[y, x + 1].Type == 'V') currentGroup.Add(grid[y, x + 1]);

                        // if the centre has teeth
                        if (currentGroup.Count > 1)
                        {
                            // create a new rotatable group using the list and tile we just found
                            RotatableGroup group = new RotatableGroup(currentGroup, grid[y, x]);


                            groups.Add(group);


                            foreach (var tile in currentGroup)
                            {
                                tile.RotatableGroup = group;  // assign the cog reference to each tile; now we will know information about the rest of the cog just from a single tile
                            }
                        }
                    }
                }
            }

            return groups;
        }
    }

    public class PushableBlock
    {
        public List<Tile> Tiles { get; set; }

        // constructor to initialise the block with a list of tiles
        public PushableBlock(List<Tile> tiles)
        {
            Tiles = tiles;
        }

        // method used to find all block in the current grid and allocate each box tile to their respective blocks
        public static List<PushableBlock> GetPushableBlocks(Tile[,] grid)
        {

            List<PushableBlock> blocks = new List<PushableBlock>();

            // create a boolean grid to ensure that, when stumbling upon a new tile that neighbours an old one, we do not double count the old one
            bool[,] visited = new bool[grid.GetLength(0), grid.GetLength(1)];

            for (int y = 0; y < grid.GetLength(0) - 1; y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    if (!visited[y, x] && grid[y, x].Type == 'B')  // look for 'B' tiles
                    {
                        List<Tile> currentBlock = new List<Tile>();
                        // flood fill ; check each adjacent tile until no more neighbouring boxes can be found
                        FloodFill(grid, x, y, visited, currentBlock);

                        // if the box is not an independent one
                        if (currentBlock.Count > 1)
                        {
                            // create a new block using the list of boxes
                            PushableBlock block = new PushableBlock(currentBlock);
                            blocks.Add(block);

                            foreach (var tile in currentBlock)
                            {
                                tile.Block = block;  // assign the block reference to each tile
                            }
                        }
                    }
                }
            }

            return blocks;
        }

        // flood fill algorithm; check if the current tile is part of a block, and if it is, check all adjacent tiles until no more found
        private static void FloodFill(Tile[,] grid, int startX, int startY, bool[,] visited, List<Tile> block)
        {
            // stack is used to hold any coordinates left to process; easiest data structure to add and remove values with for use case
            // tuple is used to represent these coordinates, so that assignments can be easily made
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();

            // start with the input coordinates
            stack.Push(Tuple.Create(startX, startY));

            // while there are coordinates to process
            while (stack.Count > 0)
            {
                // assign the last coordinates in the stack
                var (x, y) = stack.Pop();

                // if the tile is out of bounds, skip the current iteration
                if (x < 0 || x >= grid.GetLength(1) || y < 0 || y >= grid.GetLength(0) || visited[y, x])
                    continue;

                // assign true so that the check in GetPushableBlocks works as intended
                visited[y, x] = true;

                // if we have found another box
                if (grid[y, x].Type == 'B')
                {
                    // add the box to the block object
                    block.Add(grid[y, x]);

                    // add neighbouring tiles to the stack
                    stack.Push(Tuple.Create(x + 1, y));  // right
                    stack.Push(Tuple.Create(x - 1, y));  // left
                    stack.Push(Tuple.Create(x, y + 1));  // down
                    stack.Push(Tuple.Create(x, y - 1));  // up
                }
            }
        }
    }

    // class used to store the players information; particularly their position
    // it would be difficult to handle player movement if it were a tile so their position is an empty tile with a sprite drawn on it
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Player(int startX, int startY)
        {
            X = startX;
            Y = startY;
        }
    }

    public class Level
    {
        // 2 dimensional array used to represent the level
        public Tile[,] Grid { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Player Player { get; private set; }
        private Dictionary<char, Image> Sprites;
        public Dictionary<string, int> Times;

        // normal level constructor 
        public Level(string[] levelData, Dictionary<char, Image> spriteMap)
        {
            // assign the sprite map so that other methods have access to it i.e. when creating new tiles
            Sprites = spriteMap;

            Height = levelData.Length;
            Width = levelData[0].Length;
            Grid = new Tile[Height, Width];

            for (int y = 0; y < Height - 1; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    // the level is stored as a grid of tile types - single characters - so simply assign that value to the tile
                    char tileType = levelData[y][x];

                    // if this is a cog tooth
                    if (tileType == 'V')
                    {   // find the appropriate sprite by finding the tooths position relative to the cog centre
                        if (levelData[y + 1][x] == 'C') Grid[y, x] = new Tile('V', spriteMap['1'], x, y);
                        else if (levelData[y - 1][x] == 'C') Grid[y, x] = new Tile('V', spriteMap['3'], x, y);
                        else if (levelData[y][x - 1] == 'C') Grid[y, x] = new Tile('V', spriteMap['2'], x, y);
                        else if (levelData[y][x + 1] == 'C') Grid[y, x] = new Tile('V', spriteMap['4'], x, y);
                        continue;
                    }


                    Grid[y, x] = new Tile(tileType, spriteMap.ContainsKey(tileType) ? spriteMap[tileType] : null, x, y);

                    if (tileType == 'P')  // store player position
                    {
                        Player = new Player(x, y);
                        Grid[y, x] = new Tile('O', spriteMap['O'], x, y);  // replace player tile with empty space
                    }
                }
            }

            string[] metadata = levelData[15].Split(',');
            Times = new Dictionary<string, int>
            {
                {"Gold", int.Parse(metadata[0])},
                {"Silver", int.Parse(metadata[1])},
                {"Bronze", int.Parse(metadata[2])}
            };

            // use static methods to assign blocks and cogs to appropriate tiles, now that we have the grid loaded
            PushableBlock.GetPushableBlocks(Grid);
            RotatableGroup.GetRotatableGroups(Grid);
        }

        // method to deep copy a level; simply assigning it to another creates a shallow copy, so this is needed for backing up
        public static Tile[,] DeepCopyGrid(Tile[,] original)
        {
            int rows = original.GetLength(0);
            int cols = original.GetLength(1);

            // create a grid of the original size
            Tile[,] copy = new Tile[rows, cols];

            // create dictionaries that will stored original blocks and cogs and their respective cloned counterparts
            Dictionary<PushableBlock, PushableBlock> clonedBlocks = new Dictionary<PushableBlock, PushableBlock>();
            Dictionary<RotatableGroup, RotatableGroup> clonedRotatableGroups = new Dictionary<RotatableGroup, RotatableGroup>();
            for (int y = 0; y < rows - 1; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    // create a new Tile object for each one in the original grid
                    copy[y, x] = new Tile(original[y, x], clonedBlocks, clonedRotatableGroups);
                }
            }

            // as each block object contains a reference to all of the tiles that make it up,
            // go through each tile in the original list, and store the cloned counterpart in the cloned block
            // this is allowed as boxes will have the same coordinates as before
            foreach (var kvp in clonedBlocks)
            {
                PushableBlock originalBlock = kvp.Key;
                PushableBlock clonedBlock = kvp.Value;

                foreach (var tile in originalBlock.Tiles)
                {
                    clonedBlock.Tiles.Add(copy[tile.Y, tile.X]);
                }
            }

            // ditto but for cogs
            foreach (var kvp in clonedRotatableGroups)
            {
                RotatableGroup originalGroup = kvp.Key;
                RotatableGroup clonedGroup = kvp.Value;

                foreach (var tile in originalGroup.VTiles)
                {
                    clonedGroup.VTiles.Add(copy[tile.Y, tile.X]);
                }
            }
            return copy;
        }

        // movement function for the player
        public bool MovePlayer(int dx, int dy)
        {
            int newX = Player.X + dx;
            int newY = Player.Y + dy;
            if (newX < 0 || newX >= Width || newY < 0 || newY >= Height) return false;  // out of bounds

            Tile targetTile = Grid[newY, newX];

            // if target tile is empty, move player
            if (!targetTile.IsSolid)
            {
                Player.X = newX;
                Player.Y = newY;
                return true;
            }
            // if the current tile belongs to a block
            else if (targetTile.Block != null)
            {
                return MovePlayerWithBlock(targetTile, dx, dy, newX, newY);
            }
            else if (targetTile.IsPushable)
            {
                return MovePlayerWithBox(targetTile, newX, newY, dx, dy);
            }

            else if (targetTile.IsRotatable)
            {
                return MovePlayerWithCog(targetTile, newX, newY, dx, dy);
            }

            return false;  // assume that movement cannot occur
        }

        // handle movement into a block group
        public bool MovePlayerWithBlock(Tile targetTile, int dx, int dy, int newX, int newY)
        {
            // check if all tiles in the block can move in the direction
            foreach (var tile in targetTile.Block.Tiles)
            {
                // the coordinates of the tile if it were pushed
                int newTileX = tile.X + dx;
                int newTileY = tile.Y + dy;

                // check if new position is valid (in bounds and not blocked)
                if (newTileX < 0 || newTileX >= Grid.GetLength(1) || newTileY < 0 || newTileY >= Grid.GetLength(0))
                    return false; // Out of bounds

                if (Grid[newTileY, newTileX].IsSolid && Grid[newTileY, newTileX].Block != tile.Block)  // if any tile is blocked, can't move. ensure that the blocked tile isn't just another box before movement
                    return false;
            }

            // sort tiles based on movement direction to avoid overwriting
            // multiplying to create positive / negative depending on direction
            // i.e. , if the movement is to the right, then the rightmost tiles will be processed first as they will be at the start of the list
            List<Tile> sortedTiles = targetTile.Block.Tiles.OrderByDescending(t => dx != 0 ? t.X * dx : t.Y * dy).ToList();

            // if all tiles can move, move the block
            foreach (var tile in sortedTiles)
            {
                int newTileX = tile.X + dx;  // calculate the new position
                int newTileY = tile.Y + dy;

                // place empty space at the original tile position
                Grid[tile.Y, tile.X] = new Tile('O', Sprites['O'], tile.X, tile.Y);

                // move the tile's position by adding dx, dy
                tile.X += dx;
                tile.Y += dy;

                // place the tile in the new position in the grid
                Grid[newTileY, newTileX] = tile;             
            }

            Player.X = newX;
            Player.Y = newY;

            return true;  // Successfully moved the block
        }

        // handle movement into an individual box
        public bool MovePlayerWithBox(Tile targetTile, int newX, int newY, int dx, int dy)
        {

            // coordinates of the box if it were pushed
            int pushX = newX + dx;
            int pushY = newY + dy;

            if (pushX < 0 || pushX >= Width || pushY < 0 || pushY >= Height) return false; // out of bounds

            // tile which the box is trying to get pushed onto
            Tile pushTile = Grid[pushY, pushX];

            if (!pushTile.IsSolid)  // if space behind pushable object is empty, push it
            {
                // swap the box position by creating new tiles with appropriate types
                Grid[pushY, pushX] = new Tile('I', targetTile.Sprite, pushX, pushY);
                Grid[newY, newX] = new Tile('O', Sprites['O'], newX, newY);

                // move the player
                Player.X = newX;
                Player.Y = newY;
                return true;
            }

            return false;
        }

        // handle movement into a cog
        public bool MovePlayerWithCog(Tile targetTile, int newX, int newY, int dx, int dy)
        {
            // backup grid in case we need to revert
            Tile[,] backupGrid = DeepCopyGrid(Grid);

            // find the direction of the movement so we know where to place teeth
            bool? clockwise = IsRotationClockwise(newX, newY, dx, dy);
            if (clockwise == null) return false; // neither clockwise nor anticlockwise motion - normal to the centre

            // declare variables to be used in calculations and replacements
            int centreX = targetTile.RotatableGroup.CentreTile.X;
            int centreY = targetTile.RotatableGroup.CentreTile.Y;
            RotatableGroup currentGroup = targetTile.RotatableGroup;

            // find the value by which each tooth's x or y coordinate will change depending on the rotation direction
            int incrementer = (clockwise == true) ? 1 : -1;

            // record original positions of our rotating cog's tiles
            Dictionary<Tile, Point> originalPositions = currentGroup.VTiles
                .ToDictionary(tile => tile, tile => new Point(tile.X, tile.Y));

            // reposition the rotating cog's teeth ---
            // helper: checks and places tooth if valid.
            bool CheckAndPlace(Tile neighbour, int targetY, int targetX)
            {
                if (neighbour == null) return false; // stop rotation if tile doesn't exist

                bool isAir = neighbour.Type == 'O';

                // check if it's a tooth tile, and if it belongs to the same group as the one we're rotating
                bool isValidVBlock = neighbour.Type == 'V' &&
                                     neighbour.RotatableGroup != null &&
                                     neighbour.RotatableGroup.CentreTile.X == currentGroup.CentreTile.X &&
                                     neighbour.RotatableGroup.CentreTile.Y == currentGroup.CentreTile.Y;

                // check if we're targetting an empty tile or a tile belonging to the same group
                bool isValidTarget = (Grid[targetY, targetX].RotatableGroup == null && Grid[targetY, targetX].IsSolid == false) ||
                                     (Grid[targetY, targetX].RotatableGroup != null && Grid[targetY, targetX].RotatableGroup.CentreTile.X == currentGroup.CentreTile.X &&
                                      Grid[targetY, targetX].RotatableGroup.CentreTile.Y == currentGroup.CentreTile.Y);
                // if the current tile is valid and we're targetting a valid tile
                if ((isAir || isValidVBlock) && isValidTarget)
                {
                    Grid[targetY, targetX] = neighbour;
                    // update tile's internal coordinates.
                    neighbour.X = targetX;
                    neighbour.Y = targetY;
                    return true;
                }
                // if the current tile is air or a solid block which isn't a tooth
                else if (isAir || !isValidVBlock && neighbour.IsSolid)
                {
                    return true;
                    // do not perform movement, as rotation does not mean a solid block or air is moved, but do return true, as rotation should only be prevented if a tooth will collide with a solid block
                }

                return false;
            }

            // determine the neighbour tiles from the current grid state.
            Tile left = Grid[centreY, centreX - 1];
            Tile bottom = Grid[centreY + 1, centreX];
            Tile right = Grid[centreY, centreX + 1];
            Tile top = Grid[centreY - 1, centreX];

            // reposition these neighbours relative to the centre
            // use the return values from the helper method to ensure that the rotation has completed successfully
            if (!(CheckAndPlace(left, centreY - incrementer, centreX) &&
            CheckAndPlace(bottom, centreY, centreX - incrementer) &&
            CheckAndPlace(right, centreY + incrementer, centreX) &&
            CheckAndPlace(top, centreY, centreX + incrementer)))
            {

                Grid = backupGrid;
                return false; // Abort rotation

            };

            // cleanup any original positions of our cog that are now empty
            // hashset used for performance
            HashSet<Point> newPositions = new HashSet<Point>(
                currentGroup.VTiles.Select(tile => new Point(tile.X, tile.Y))
            );

            foreach (var kvp in originalPositions)
            {
                // compare new positions with original positions. if there is no overlap, set the old position equal to air
                Point origPos = kvp.Value;
                if (!newPositions.Contains(origPos))
                {
                    Grid[origPos.Y, origPos.X] = new Tile('O', Sprites['O'], origPos.X, origPos.Y);
                }
            }

            // update tooth sprites
            // check if each position is a tooth, then if it belongs to the same group before setting values to prevent mixing between cogs
            if (Grid[centreY - 1, centreX].Type == 'V' &&
                currentGroup.CentreTile.X == Grid[centreY - 1, centreX].RotatableGroup.CentreTile.X &&
                currentGroup.CentreTile.Y == Grid[centreY - 1, centreX].RotatableGroup.CentreTile.Y)
            {
                Grid[centreY - 1, centreX].Sprite = Sprites['1'];
            }
            if (Grid[centreY + 1, centreX].Type == 'V' &&
                currentGroup.CentreTile.X == Grid[centreY + 1, centreX].RotatableGroup.CentreTile.X &&
                currentGroup.CentreTile.Y == Grid[centreY + 1, centreX].RotatableGroup.CentreTile.Y)
            {
                Grid[centreY + 1, centreX].Sprite = Sprites['3'];
            }
            if (Grid[centreY, centreX + 1].Type == 'V' &&
                currentGroup.CentreTile.X == Grid[centreY, centreX + 1].RotatableGroup.CentreTile.X &&
                currentGroup.CentreTile.Y == Grid[centreY, centreX + 1].RotatableGroup.CentreTile.Y)
            {
                Grid[centreY, centreX + 1].Sprite = Sprites['2'];
            }
            if (Grid[centreY, centreX - 1].Type == 'V' &&
                currentGroup.CentreTile.X == Grid[centreY, centreX - 1].RotatableGroup.CentreTile.X &&
                currentGroup.CentreTile.Y == Grid[centreY, centreX - 1].RotatableGroup.CentreTile.Y)
            {
                Grid[centreY, centreX - 1].Sprite = Sprites['4'];
            }

            // move the player if the destination tile is acceptable
            if (Grid[newY, newX].Type == 'O')
            {
                Player.X = newX;
                Player.Y = newY;
                return true;
            }
            else if (Grid[newY, newX].Type == 'V' && !Grid[newY + dy, newX + dx].IsSolid)
            {
                // if the position will be a tooth but the next one over is empty, double the movement
                // essentially like the tooth pushing the player
                Player.X = newX + dx;
                Player.Y = newY + dy;
                return true;
            }
            else
            {
                // revert to original state
                Grid = backupGrid;
                return false;
            }
        }

        // check if the rotation of the cog is clockwise, anticlockwise, or neither.
        public bool? IsRotationClockwise(int positionX, int positionY, int dx, int dy)
        {
            int RotatableGroupCentreX = Grid[positionY, positionX].RotatableGroup.CentreTile.X;
            int RotatableGroupCentreY = Grid[positionY, positionX].RotatableGroup.CentreTile.Y;
            // coordinate check is used to ensure that this condition is not activated due to a neighbouring tile centre
            // each check essentially checks: the position of the tooth relative to the centre, if the centre is part of the tooth's group, and then if the movement and position pair corresponds to a clockwise or anticlockwise movement
            if (Grid[positionY, positionX + 1].Type == 'C' && positionY == RotatableGroupCentreY && positionX + 1 == RotatableGroupCentreX && dy < 0 ||
                Grid[positionY, positionX - 1].Type == 'C' && positionY == RotatableGroupCentreY && positionX - 1 == RotatableGroupCentreX && dy > 0 ||
                    Grid[positionY + 1, positionX].Type == 'C' && positionY + 1 == RotatableGroupCentreY && positionX == RotatableGroupCentreX && dx > 0 ||
                        Grid[positionY - 1, positionX].Type == 'C' && positionY - 1 == RotatableGroupCentreY && positionX == RotatableGroupCentreX && dx < 0)
            {
                return true;
            }
            else if (Grid[positionY, positionX + 1].Type == 'C' && positionY == RotatableGroupCentreY && positionX + 1 == RotatableGroupCentreX && dy > 0 ||
                Grid[positionY, positionX - 1].Type == 'C' && positionY == RotatableGroupCentreY && positionX - 1 == RotatableGroupCentreX && dy < 0 ||
                    Grid[positionY + 1, positionX].Type == 'C' && positionY + 1 == RotatableGroupCentreY && positionX == RotatableGroupCentreX && dx < 0 ||
                        Grid[positionY - 1, positionX].Type == 'C' && positionY - 1 == RotatableGroupCentreY && positionX == RotatableGroupCentreX && dx > 0)
            {
                return false;
            }
            return null;
        }

    }
}
