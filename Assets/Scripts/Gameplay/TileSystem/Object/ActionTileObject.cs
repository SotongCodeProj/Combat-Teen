using System.Collections.Generic;
using CombTeen.Gameplay.Unit.MVC;
using UnityEngine;

namespace CombTeen.Gameplay.Tile.Object
{
    public interface IActionTileData : ITileObject
    {
        public List<string> TileActionTags { get; }
        public CombatUnitControl OccupiedUnit { get; }
    }

    public class ActionTileObject : TileObject, IActionTileData
    {
        private TileView _view;
        public string name => _view.name;
        public ActionTileObject(TileView view)
        {
            _view = view;
        }

        public List<string> TileActionTags { private set; get; }
        public override Vector3 TileWorldPosition => _view.transform.localPosition;
        public CombatUnitControl OccupiedUnit { private set; get; }


        public virtual void Initial(Vector2Int tileCoordinate, params string[] actionTags)
        {
            base.Initial(tileCoordinate);
            TileActionTags = new List<string>(actionTags);
        }

        public bool IsContainTag(string tag)
        {
            return TileActionTags.Contains(tag);
        }

        public bool IsContainTags(string[] tags, TagSearch tagSearch = TagSearch.OneOfIt)
        {
            switch (tagSearch)
            {
                case TagSearch.AllOfIt:
                    return ContainAllOfIt();

                default:
                    return ContainOneOfIt();
            }

            bool ContainOneOfIt()
            {
                for (int i = 0; i < tags.Length; i++)
                {
                    if (TileActionTags.Contains(tags[i])) { return true; }
                }
                return false;
            }
            bool ContainAllOfIt()
            {
                for (int i = 0; i < tags.Length; i++)
                {
                    if (!TileActionTags.Contains(tags[i])) return false;
                }
                return true;
            }
        }

        public void ChangeColor(Color red)
        {
            _view.ChangeColor(red);
        }

        public void ChangeColorToDefault()
        {
            _view.ChangeColor(DefaultColor);
        }

        public void SetOccuppiedUnit(CombatUnitControl targetUnit)
        {
            OccupiedUnit = targetUnit;
        }

        public enum TagSearch
        {
            OneOfIt,
            AllOfIt
        }


    }
}
