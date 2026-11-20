import '../core/arcade.dart';
import '../core/missions.dart';
import '../core/stats.dart';
import 'farm_spec.dart';
import 'tycoon_rules.dart';

class FarmRules extends TycoonRules {
  FarmRules()
      : super(farmSpec, 'game-026-farm-empire', const [
          GameStat('harvests', 'Hasat', 'Harvests', scale: 60),
          GameStat('money_earned', 'Çiftlik geliri', 'Farm income', scale: 5000),
          GameStat('buildings_bought', 'Kurulan yapı', 'Buildings', scale: 40),
        ], const [
          MissionTemplate('harvests', 'harvests', [20, 40, 60]),
          MissionTemplate('money_earned', 'money_earned', [1666, 3333, 5000]),
        ]);
}

ArcadeRules createRules() => FarmRules();
