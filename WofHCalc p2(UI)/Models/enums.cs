using System;

namespace WofHCalc_p2_UI_.Models
{
    [Flags]
    public enum Race
    {
        unknown = 0,
        indians = 1,
        europeans = 2,
        asians = 4,
        africans = 8
    }
    public enum ResName
    {
        science = 0,
        money = 1,
        food = 2,
        wood = 3,
        iron = 4,
        fuel = 5,
        stone = 6,
        horses = 7,
        sulfur = 8,
        none1 = 9,
        uranium = 10,
        fruit = 11,
        corn = 12,
        grain = 13,
        rice = 14,
        fish = 15,
        meat = 16,
        wine = 17,
        jewelry = 18,
        clothes = 19,
        none2 = 20,
        films = 21,
        books = 22
    }
    public enum ResProdType
    {
        research = 0,
        finance = 1,
        agriculture = 2,
        industry = 3,
    }
    public enum Climate
    {
        unknown = 0,
        water = 1,
        meadows = 2,
        steppe = 3,
        desert = 4,
        snow = 5
    }

    public enum DepositName
    {
        none = 0,
        wood_meadows = 1,
        wood_steppe = 2,
        wood_snow = 3,
        oasis = 4,
        bananas = 5,
        apples = 6,
        apricots = 7,
        grape_meadows = 8,
        grape_steppe = 9,
        corn = 10,
        grain = 11,
        rice = 12,
        fish = 13,
        whales = 14,
        crabs = 15,
        oysters = 16,
        pigs = 17,
        cows = 18,
        deers = 19,
        ships_steppe = 20,
        ships_meadows = 21,
        cotton = 22,
        linen = 23,
        gold = 24,
        silver = 25,
        diamonds = 26,
        emeralds = 27,
        rubies = 28,
        pearls = 29,
        iron_snow = 30,
        iron_meadows =31,
        iron_steppe = 32,
        stone_snow = 33,
        stone_meadows = 34,
        stone_steppe = 35,
        horses = 36,
        camels = 37,
        elephants = 38,
        sulfur_meadows = 39,
        sulfur_steppe = 40,
        sulfur_desert = 41,
        gas_snow = 42,
        gas_steppe = 43,
        oil_desert = 44,
        oil_meadows = 45,
        oil_water = 46,
        coal_meadow = 47,
        coal_steppe = 48,
        uran_snow = 49,
        uran_steppe = 50,
        uran_desert = 51,
        source_of_wisdom = 52        
    }
    public enum BuildName
    {
        //fortification
        moat = 3,//ров        
        palisade = 19,//частокол
        walls = 38, //стена
        fortified_zone = 57, //укреп

        sam_batery = 101, //зенитка
        air_defense_system = 109, //пво

        //Scientific
        petroglyph = 88,
        school_of_philosophy = 33, //ФШ
        observatory = 80, //обсерва

        library = 35, //библа
        academy = 70, //академка
        university = 61, //уник
        laboratory = 72, //лаба

    //Production and finances
        lumber_mill = 5,//пилка
        farm = 6, //ферма
        granite_quarry = 12, //гранитный карьер
        mine = 21, //шахта
        animal_farm = 23,//пастбище
        fishing_snare = 84,//ловушка для рыбы
        fishing_harbor = 24,//промысловый порт
        //дом охотника
        //дом собирателя
        mint = 51,//монетный двор
        bank = 40, //банк
        winery = 22,//винодельня
        printing_office = 42,//типография
        fuel_plant = 46, //топливный завод
        weavers_house = 36,//дом ткача
        weaving_mill = 52,//ткацкая фабрика
        motionpicture_studio = 47, //киностудия
        sulphursmelting_plant = 89,//сероплавильный завод
        concentrating_plant = 66,//обогатительный завод

        forge = 90,//кузница
        factory = 49,//мануфактура
        power_plant = 54,//завод

    //town center
    //Shrine //алтарь
     //residence = , //резиденция
     //castle = , //замок
     //city_hall = , //ратуша
     //mayors_office = , //мерия


    //Hunter's house
    //Collector’s house

    //Storage and trade

    //Hut //землянка 
     //depot = , //склад
                                    //Pier //пристань
     //market = , //рынок
                                     //Harbor //порт
                                     //Takayuka depot //такаюка
                                     //Town square //площадь
                                     //Trading base //ТБ

    //Culture

    //Obelisk //обелиск
    //Museum //музей
    //Cathedral //собор
    //Theatre //театр
    //Monument //статую
    //Temple //храм
    //Monastery //монастырь

    //Military

    //Fight pit
    //Barracks
    //Stable
    //Shooting range
    //Shipyard
    //Workshop
    //Military factory
    //Spaceship factory
    //Lighthouse
    //Military base
    //Dry-dock
    //Hangar
    //Radar station

    //Demographic

    //Well
    //Tipi
     //water_intake = ,
     //fountain = ,
    //Hospital
     //house = ,
    //Aqueduct
    //Infirmary
    //Shack

    //Special

    //Embassy //посоль
    //courthouse = , //суд
    //Cache //тайник
    //Decoy //муляж
    //Chieftains mokhoro //мохро вождей







}


}