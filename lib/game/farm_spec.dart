import 'tycoon_engine.dart';

const farmSpec = TycoonSpec(
  res: [
    Res('coins', 'Para', 'Coins', 0xFFFFD60A),
    Res('wheat', 'Buğday', 'Wheat', 0xFFFFD166, sell: 0.5, keep: 20, value: 0.5),
    Res('corn', 'Mısır', 'Corn', 0xFFF4A261, sell: 0.7, keep: 20, value: 0.7),
    Res('egg', 'Yumurta', 'Eggs', 0xFFFFF3B0, sell: 2.5, keep: 6, value: 2.5),
    Res('milk', 'Süt', 'Milk', 0xFFE9ECEF, sell: 3.5, keep: 6, value: 3.5),
    Res('bread', 'Ekmek', 'Bread', 0xFFDDA15E, sell: 6, value: 6),
    Res('cheese', 'Peynir', 'Cheese', 0xFFFFB703, sell: 14, value: 14),
  ],
  blds: [
    Bld('wheat', 'Buğday tarlası', 'Wheat field', 10, make: {1: 1.0}, manual: true, start: 1, shape: 2, color: 0xFFFFD166),
    Bld('corn', 'Mısır tarlası', 'Corn field', 30, make: {2: 1.0}, manual: true, shape: 2, color: 0xFFF4A261),
    Bld('coop', 'Kümes', 'Chicken coop', 70, make: {3: 0.4}, use: {1: 0.4}, shape: 0, color: 0xFFE63946),
    Bld('barn', 'Ahır', 'Cow barn', 160, make: {4: 0.4}, use: {2: 0.6}, shape: 0, color: 0xFF9C6644),
    Bld('sprinkler', 'Sulama', 'Sprinklers', 120, boost: 0.08, shape: 6, color: 0xFF219EBC),
    Bld('harvester', 'Biçerdöver', 'Harvester', 260, make: {1: 3, 2: 2}, unlockRes: 1, unlockAt: 60, shape: 1, color: 0xFF2A9D8F),
    Bld('bakery', 'Fırın', 'Bakery', 380, make: {5: 0.4}, use: {1: 1.2, 3: 0.2}, unlockRes: 3, unlockAt: 20, shape: 5, color: 0xFFDDA15E),
    Bld('dairy', 'Mandıra', 'Dairy', 700, make: {6: 0.3}, use: {4: 0.8}, unlockRes: 4, unlockAt: 20, shape: 1, color: 0xFFFFB703),
    Bld('market', 'Pazar tezgâhı', 'Farm stand', 500, boost: 0.15, unlockRes: 1, unlockAt: 120, shape: 5, color: 0xFFE76F51),
    Bld('greenhouse', 'Sera', 'Greenhouse', 1100, make: {1: 8, 2: 6}, unlockRes: 5, unlockAt: 30, shape: 4, color: 0xFF52B788),
    Bld('truck', 'Kamyon', 'Delivery truck', 1800, boost: 0.35, unlockRes: 6, unlockAt: 20, shape: 6, color: 0xFF457B9D),
  ],
  startMoney: 30,
  clickMoney: 0.5,
  goal: TGoal.earn,
  goalTr: 'Gelir',
  goalEn: 'Income',
);
