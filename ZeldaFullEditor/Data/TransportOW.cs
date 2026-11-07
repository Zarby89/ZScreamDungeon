using System;
using static ZeldaFullEditor.OverworldMap;

namespace ZeldaFullEditor
{
    public class TransportOW
    {
        public ushort
            _vramLocation,
            _xScroll,
            _yScroll,
            _playerX,
            _playerY,
            _cameraX,
            _cameraY,
            _mapId,
            _whirlpoolPos;

        public byte
            _unk1,
            _unk2,
            AreaX,
            AreaY;

        public bool isAutomatic = true;

        public int ID = 0;

        public TransportOW(byte mapID, ushort vramLocation, ushort yScroll, ushort xScroll, ushort playerY, ushort playerX, ushort cameraY, ushort cameraX, byte unk1, byte unk2, ushort whirlpoolPos)
        {
            _mapId = mapID;
            _vramLocation = vramLocation;
            _xScroll = xScroll;
            _yScroll = yScroll;
            _playerX = Math.Clamp(playerX, 0, 4088);
            _playerY = Math.Clamp(playerY, 0, 4088);
            _cameraX = cameraX;
            _cameraY = cameraY;
            _unk1 = unk1;
            _unk2 = unk2;
            _whirlpoolPos = whirlpoolPos;

            int mapX = mapID - ((mapID / 8) * 8);
            int mapY = mapID / 8;

            AreaX = (byte)(Math.Abs(playerX - (mapX * 512)) / 16);
            AreaY = (byte)(Math.Abs(playerY - (mapY * 512)) / 16);

            ID = ROM.uniqueTransportID++;
        }

        public void updateMapStuff(byte mapID, Overworld ow)
        {
            AreaSizeEnum areaSize = ow.AllMaps[mapID].AreaSize;
            int areaSizeX = 256;
            int areaSizeY = 256;

            areaSizeX = areaSize == AreaSizeEnum.LargeArea || areaSize == AreaSizeEnum.WideArea ? 768 : 256;
            areaSizeY = areaSize == AreaSizeEnum.LargeArea || areaSize == AreaSizeEnum.TallArea ? 768 : 256;

            _mapId = mapID;
            var mapx = (mapID & 7) << 9;
            var mapy = (mapID & 0x38) << 6;
            _xScroll = (ushort)(_playerX - 134);
            _yScroll = (ushort)(_playerY - 78);

            if (_xScroll < mapx)
            {
                _xScroll = (ushort)mapx;
            }

            if (_yScroll < mapy)
            {
                _yScroll = (ushort)mapy;
            }

            if (_xScroll > mapx + areaSizeX)
            {
                _xScroll = (ushort)(mapx + areaSizeX);
            }

            if (_yScroll > mapy + areaSizeY + 30)
            {
                _yScroll = (ushort)(mapy + areaSizeY + 30);
            }

            _cameraX = _playerX;
            _cameraY = (ushort)(_playerY + 19);

            if (_cameraX < mapx + 127)
            {
                _cameraX = (ushort)(mapx + 127);
            }
            else if (_cameraX > mapx + 127 + areaSizeX)
            {
                _cameraX = (ushort)(mapx + 127 + areaSizeX);
            }

            if (_cameraY < mapy + 111)
            {
                _cameraY = (ushort)(mapy + 111);
            }
            else if (_cameraY > mapy + 143 + areaSizeY)
            {
                _cameraY = (ushort)(mapy + 143 + areaSizeY);
            }

            var vramXScroll = (ushort)(_xScroll - mapx);
            var vramYScroll = (ushort)(_yScroll - mapy);

            _vramLocation = (ushort)((vramYScroll & 0xFFF0) << 3 | (vramXScroll & 0xFFF0) >> 3);

            Console.WriteLine("Transport: " + ID.ToString("X2") + " MapID: " + mapID.ToString("X2") + " X: " + _playerX + " Y: " + _playerY);
        }
    }
}
