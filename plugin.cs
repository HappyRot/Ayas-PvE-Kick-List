using System.Linq;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO; // Used for Licensing 
using AimsharpWow.API; //needed to access Aimsharp API 
using System.Net;
using System.Management;

namespace AimsharpWow.Modules
{
    public class PvEKicks : Plugin
    {
        private static string Language = "English";
        #region translate
        private static string Quell_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Unterdrücken";
                case "Español":
                    return "Sofocar";
                case "Français":
                    return "Apaisement";
                case "Italiano":
                    return "Sedazione";
                case "Português Brasileiro":
                    return "Supressão";
                case "Русский":
                    return "Подавление";
                case "한국어":
                    return "진압";
                case "简体中文":
                    return "镇压";
                default:
                    return "Quell";
            }
        }
        private static string CounterShot_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Gegenschuss";
                case "Español":
                    return "Contradisparo";
                case "Français":
                    return "Tir de riposte";
                case "Italiano":
                    return "Tiro di Contrasto";
                case "Português Brasileiro":
                    return "Tiro Retaliatório";
                case "Русский":
                    return "Встречный выстрел";
                case "한국어":
                    return "반격의 사격";
                case "简体中文":
                    return "反制射击";
                default:
                    return "Counter Shot";
            }
        }
        private static string Muzzle_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Maulkorb";
                case "Español":
                    return "Amordazar";
                case "Français":
                    return "Muselière";
                case "Italiano":
                    return "Museruola";
                case "Português Brasileiro":
                    return "Focinheira";
                case "Русский":
                    return "Намордник";
                case "한국어":
                    return "재갈";
                case "简体中文":
                    return "压制";
                default:
                    return "Muzzle";
            }
        }
        private static string Intimidation_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Einschüchterung";
                case "Español":
                    return "Intimidación";
                case "Français":
                    return "Intimidation";
                case "Italiano":
                    return "Intimidazione";
                case "Português Brasileiro":
                    return "Intimidação";
                case "Русский":
                    return "Устрашение";
                case "한국어":
                    return "위협";
                case "简体中文":
                    return "胁迫";
                default:
                    return "Intimidation";
            }
        }
        private static string Kick_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Tritt";
                case "Español":
                    return "Patada";
                case "Français":
                    return "Coup de pied";
                case "Italiano":
                    return "Calcio";
                case "Português Brasileiro":
                    return "Chute";
                case "Русский":
                    return "Пинок";
                case "한국어":
                    return "발차기";
                case "简体中文":
                    return "脚踢";
                default:
                    return "Kick";
            }
        }
        private static string Gouge_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Solarplexus";
                case "Español":
                    return "Gubia";
                case "Français":
                    return "Suriner";
                case "Italiano":
                    return "Sfregio Oculare";
                case "Português Brasileiro":
                    return "Esfaquear";
                case "Русский":
                    return "Парализующий удар";
                case "한국어":
                    return "후려치기";
                case "简体中文":
                    return "凿击";
                default:
                    return "Gouge";
            }
        }
        private static string KidneyShot_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Nierenhieb";
                case "Español":
                    return "Golpe en los riñones";
                case "Français":
                    return "Aiguillon perfide";
                case "Italiano":
                    return "Colpo ai Reni";
                case "Português Brasileiro":
                    return "Golpe no Rim";
                case "Русский":
                    return "Удар по почкам";
                case "한국어":
                    return "급소 가격";
                case "简体中文":
                    return "肾击";
                default:
                    return "Kidney Shot";
            }
        }
        private static string Blind_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Blenden";
                case "Español":
                    return "Ceguera";
                case "Français":
                    return "Cécité";
                case "Italiano":
                    return "Accecamento";
                case "Português Brasileiro":
                    return "Cegar";
                case "Русский":
                    return "Ослепление";
                case "한국어":
                    return "실명";
                case "简体中文":
                    return "致盲";
                default:
                    return "Blind";
            }
        }
        private static string Silence_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Stille";
                case "Español":
                    return "Silencio";
                case "Français":
                    return "Silence";
                case "Italiano":
                    return "Silenzio";
                case "Português Brasileiro":
                    return "Silêncio";
                case "Русский":
                    return "Безмолвие";
                case "한국어":
                    return "침묵";
                case "简体中文":
                    return "沉默";
                default:
                    return "Silence";
            }
        }
        private static string Disrupt_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Unterbrechen";
                case "Español":
                    return "Interrumpir";
                case "Français":
                    return "Ébranlement";
                case "Italiano":
                    return "Distruzione";
                case "Português Brasileiro":
                    return "Interromper";
                case "Русский":
                    return "Прерывание";
                case "한국어":
                    return "분열";
                case "简体中文":
                    return "瓦解";
                default:
                    return "Disrupt";
            }
        }
        private static string ChaosNova_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Chaosnova";
                case "Español":
                    return "Nova de caos";
                case "Français":
                    return "Nova du chaos";
                case "Italiano":
                    return "Nova del Caos";
                case "Português Brasileiro":
                    return "Nova do Caos";
                case "Русский":
                    return "Кольцо Хаоса";
                case "한국어":
                    return "혼돈의 회오리";
                case "简体中文":
                    return "混乱新星";
                default:
                    return "Chaos Nova";
            }
        }
        private static string FelEruption_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Teufelseruption";
                case "Español":
                    return "Erupción vil";
                case "Français":
                    return "Éruption gangrenée";
                case "Italiano":
                    return "Vileruzione";
                case "Português Brasileiro":
                    return "Erupção Vil";
                case "Русский":
                    return "Извержение Скверны";
                case "한국어":
                    return "지옥 분출";
                case "简体中文":
                    return "邪能爆发";
                default:
                    return "Fel Eruption";
            }
        }
        private static string Metamorphosis_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Metamorphose";
                case "Español":
                    return "Metamorfosis";
                case "Français":
                    return "Métamorphose";
                case "Italiano":
                    return "Metamorfosi Demoniaca";
                case "Português Brasileiro":
                    return "Metamorfose";
                case "Русский":
                    return "Метаморфоза";
                case "한국어":
                    return "탈태";
                case "简体中文":
                    return "恶魔变形";
                default:
                    return "Metamorphosis";
            }
        }
        private static string Windshear_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Windschere";
                case "Español":
                    return "Viento esquilador";
                case "Français":
                    return "Cisailles";
                case "Italiano":
                    return "Tagliavento";
                case "Português Brasileiro":
                    return "Cortavento";
                case "Русский":
                    return "Ветрорез";
                case "한국어":
                    return "칼바람";
                case "简体中文":
                    return "风剪";
                default:
                    return "Windshear";
            }
        }
        private static string CapacitorTotem_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Totem der Energiespeicherung";
                case "Español":
                    return "Tótem capacitador";
                case "Français":
                    return "Totem condensateur";
                case "Italiano":
                    return "Totem della Condensazione Elettrica";
                case "Português Brasileiro":
                    return "Totem Capacitor";
                case "Русский":
                    return "Тотем конденсации";
                case "한국어":
                    return "축전 토템";
                case "简体中文":
                    return "电能图腾";
                default:
                    return "Capacitor Totem";
            }
        }
        private static string Rebuke_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Zurechtweisung";
                case "Español":
                    return "Reprimenda";
                case "Français":
                    return "Réprimandes";
                case "Italiano":
                    return "Predica";
                case "Português Brasileiro":
                    return "Repreensão";
                case "Русский":
                    return "Укор";
                case "한국어":
                    return "비난";
                case "简体中文":
                    return "责难";
                default:
                    return "Rebuke";
            }
        }
        private static string AvengersShield_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Schild des Rächers";
                case "Español":
                    return "Escudo de vengador";
                case "Français":
                    return "Bouclier du vengeur";
                case "Italiano":
                    return "Scudo del Vendicatore";
                case "Português Brasileiro":
                    return "Escudo do Vingador";
                case "Русский":
                    return "Щит мстителя";
                case "한국어":
                    return "응징의 방패";
                case "简体中文":
                    return "复仇者之盾";
                default:
                    return "Avenger's Shield";
            }
        }
        private static string HammerofJustice_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Hammer der Gerechtigkeit";
                case "Español":
                    return "Martillo de Justicia";
                case "Français":
                    return "Marteau de la justice";
                case "Italiano":
                    return "Martello della Giustizia";
                case "Português Brasileiro":
                    return "Martelo da Justiça";
                case "Русский":
                    return "Молот правосудия";
                case "한국어":
                    return "심판의 망치";
                case "简体中文":
                    return "制裁之锤";
                default:
                    return "Hammer of Justice";
            }
        }
        private static string MindFreeze_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Gedankenfrost";
                case "Español":
                    return "Helada mental";
                case "Français":
                    return "Gel de l'esprit";
                case "Italiano":
                    return "Gelo Mentale";
                case "Português Brasileiro":
                    return "Congelar Mente";
                case "Русский":
                    return "Заморозка разума";
                case "한국어":
                    return "정신 얼리기";
                case "简体中文":
                    return "心灵冰冻";
                default:
                    return "Mind Freeze";
            }
        }
        private static string Asphyxiate_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Ersticken";
                case "Español":
                    return "Asfixiar";
                case "Français":
                    return "Asphyxier";
                case "Italiano":
                    return "Asfissia";
                case "Português Brasileiro":
                    return "Asfixiar";
                case "Русский":
                    return "Асфиксия";
                case "한국어":
                    return "어둠의 질식";
                case "简体中文":
                    return "窒息";
                default:
                    return "Asphyxiate";
            }
        }
        private static string DeathGrip_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Todesgriff";
                case "Español":
                    return "Atracción letal";
                case "Français":
                    return "Poigne de la mort";
                case "Italiano":
                    return "Presa Mortale";
                case "Português Brasileiro":
                    return "Garra da Morte";
                case "Русский":
                    return "Хватка смерти";
                case "한국어":
                    return "죽음의 손아귀";
                case "简体中文":
                    return "死亡之握";
                default:
                    return "Death Grip";
            }
        }
        private static string Strangulate_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Strangulieren";
                case "Español":
                    return "Estrangular";
                case "Français":
                    return "Strangulation";
                case "Italiano":
                    return "Strangolamento";
                case "Português Brasileiro":
                    return "Estrangular";
                case "Русский":
                    return "Удушение";
                case "한국어":
                    return "질식시키기";
                case "简体中文":
                    return "绞袭";
                default:
                    return "Strangulate";
            }
        }
        private static string Gnaw_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Nagen";
                case "Español":
                    return "Roer";
                case "Français":
                    return "Ronger";
                case "Italiano":
                    return "Rosicchiamento";
                case "Português Brasileiro":
                    return "Mordisco";
                case "Русский":
                    return "Отгрызть";
                case "한국어":
                    return "물어뜯기";
                case "简体中文":
                    return "撕扯";
                default:
                    return "Gnaw";
            }
        }
        private static string SkullBash_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Schädelstoß";
                case "Español":
                    return "Testarazo";
                case "Français":
                    return "Coup de crâne";
                case "Italiano":
                    return "Craniata";
                case "Português Brasileiro":
                    return "Esmagar Crânio";
                case "Русский":
                    return "Лобовая атака";
                case "한국어":
                    return "두개골 강타";
                case "简体中文":
                    return "迎头痛击";
                default:
                    return "Skull Bash";
            }
        }
        private static string SolarBeam_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Sonnenstrahl";
                case "Español":
                    return "Rayo solar";
                case "Français":
                    return "Rayon solaire";
                case "Italiano":
                    return "Fascio Solare";
                case "Português Brasileiro":
                    return "Raio Solar";
                case "Русский":
                    return "Столп солнечного света";
                case "한국어":
                    return "태양 광선";
                case "简体中文":
                    return "日光术";
                default:
                    return "Solar Beam";
            }
        }
        private static string MightyBash_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Mächtiger Hieb";
                case "Español":
                    return "Azote poderoso";
                case "Français":
                    return "Rossée puissante";
                case "Italiano":
                    return "Urto Vigoroso";
                case "Português Brasileiro":
                    return "Trombada Poderosa";
                case "Русский":
                    return "Мощное оглушение";
                case "한국어":
                    return "거센 강타";
                case "简体中文":
                    return "蛮力猛击";
                default:
                    return "Mighty Bash";
            }
        }
        private static string FeralCharge_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Wilde Attacke";
                case "Español":
                    return "Carga feral";
                case "Français":
                    return "Charge farouche";
                case "Italiano":
                    return "Carica Ferina";
                case "Português Brasileiro":
                    return "Investida Feral";
                case "Русский":
                    return "Звериный рывок";
                case "한국어":
                    return "야성의 돌진";
                case "简体中文":
                    return "野性冲锋";
                default:
                    return "Feral Charge";
            }
        }
        private static string SpellLock_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Zaubersperre";
                case "Español":
                    return "Bloqueo de hechizo";
                case "Français":
                    return "Verrou magique";
                case "Italiano":
                    return "Blocca Incantesimo";
                case "Português Brasileiro":
                    return "Bloquear Feitiço";
                case "Русский":
                    return "Запрет чар";
                case "한국어":
                    return "주문 잠금";
                case "简体中文":
                    return "法术封锁";
                default:
                    return "Spell Lock";
            }
        }
        private static string OpticalBlast_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Augenstrahl";
                case "Español":
                    return "Explosión óptica";
                case "Français":
                    return "Déflagration optique";
                case "Italiano":
                    return "Detonazione Ottica";
                case "Português Brasileiro":
                    return "Impacto Óptico";
                case "Русский":
                    return "Оптический удар";
                case "한국어":
                    return "안구 광선";
                case "简体中文":
                    return "眼棱爆炸";
                default:
                    return "Optical Blast";
            }
        }
        private static string Counterspell_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Gegenzauber";
                case "Español":
                    return "Contrahechizo";
                case "Français":
                    return "Contresort";
                case "Italiano":
                    return "Controincantesimo";
                case "Português Brasileiro":
                    return "Contrafeitiço";
                case "Русский":
                    return "Антимагия";
                case "한국어":
                    return "마법 차단";
                case "简体中文":
                    return "法术反制";
                default:
                    return "Counterspell";
            }
        }
        private static string SpearHandStrike_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Speerhandstoß";
                case "Español":
                    return "Golpe de mano de lanza";
                case "Français":
                    return "Pique de main";
                case "Italiano":
                    return "Compressione Tracheale";
                case "Português Brasileiro":
                    return "Golpe Mão de Lança";
                case "Русский":
                    return "Рука-копье";
                case "한국어":
                    return "손날 찌르기";
                case "简体中文":
                    return "切喉手";
                default:
                    return "Spear Hand Strike";
            }
        }
        private static string Paralysis_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Paralyse";
                case "Español":
                    return "Parálisis";
                case "Français":
                    return "Paralysie";
                case "Italiano":
                    return "Paralisi";
                case "Português Brasileiro":
                    return "Paralisia";
                case "Русский":
                    return "Паралич";
                case "한국어":
                    return "마비";
                case "简体中文":
                    return "分筋错骨";
                default:
                    return "Paralysis";
            }
        }
        private static string LegSweep_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Fußfeger";
                case "Español":
                    return "Barrido de pierna";
                case "Français":
                    return "Balayement de jambe";
                case "Italiano":
                    return "Calcio a Spazzata";
                case "Português Brasileiro":
                    return "Rasteira";
                case "Русский":
                    return "Круговой удар ногой";
                case "한국어":
                    return "팽이 차기";
                case "简体中文":
                    return "扫堂腿";
                default:
                    return "Leg Sweep";
            }
        }
        private static string Pummel_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Zuschlagen";
                case "Español":
                    return "Zurrar";
                case "Français":
                    return "Volée de coups";
                case "Italiano":
                    return "Pugno Diversivo";
                case "Português Brasileiro":
                    return "Murro";
                case "Русский":
                    return "Зуботычина";
                case "한국어":
                    return "들이치기";
                case "简体中文":
                    return "拳击";
                default:
                    return "Pummel";
            }
        }
        private static string StormBolt_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Sturmblitz";
                case "Español":
                    return "Descarga tormentosa";
                case "Français":
                    return "Éclair de tempête";
                case "Italiano":
                    return "Dardo della Tempesta";
                case "Português Brasileiro":
                    return "Seta Tempestuosa";
                case "Русский":
                    return "Удар громовержца";
                case "한국어":
                    return "폭풍망치";
                case "简体中文":
                    return "风暴之锤";
                default:
                    return "Storm Bolt";
            }
        }
        private static string IntimidatingShout_SpellName()
        {
            switch (Language)
            {
                case "Deutsch":
                    return "Drohruf";
                case "Español":
                    return "Grito intimidador";
                case "Français":
                    return "Cri d’intimidation";
                case "Italiano":
                    return "Urlo Intimidatorio";
                case "Português Brasileiro":
                    return "Brado Intimidador";
                case "Русский":
                    return "Устрашающий крик";
                case "한국어":
                    return "위협의 외침";
                case "简体中文":
                    return "破胆怒吼";
                default:
                    return "Intimidating Shout";
            }
        }

        #endregion
        bool authorized = true;
        public class Enemy
        {
            public string Unit = "";
            public int HP = 0;
            public bool IsInterruptable = false;
            public bool IsChanneling = false;
            public int CastingID = 0;
            public int CastingRemaining = 0;
            public int CastingElapsed = 0;
            public int Range = 0;
            public string Spec = "none";
            public Enemy(string unit)
            {
                Unit = unit;
            }
            public void Update()
            {
                HP = Aimsharp.Health(Unit);
                if (HP == 0)
                {
                    IsInterruptable = false;
                    IsChanneling = false;
                    CastingID = 0;
                    CastingRemaining = 0;
                    CastingElapsed = 0;
                    Range = 0;
                    Spec = "none";
                }
                else
                {
                    IsInterruptable = Aimsharp.IsInterruptable(Unit);
                    IsChanneling = Aimsharp.IsChanneling(Unit);
                    CastingID = Aimsharp.CastingID(Unit);
                    CastingRemaining = Aimsharp.CastingRemaining(Unit);
                    CastingElapsed = Aimsharp.CastingElapsed(Unit);
                    Range = Aimsharp.Range(Unit);
                    Spec = Aimsharp.GetSpec(Unit);
                }
            }
        }
        string[] immunes = { "Divine Shield", "Aspect of the Turtle" };
        string[] physical_immunes = { "Blessing of Protection" };
        string[] spell_immunes = { "Nether Ward", "Grounding Totem Effect", "Spell Reflection", "Anti-Magic Shell" };
        Random rng = new Random();
        Stopwatch RngTimer = new Stopwatch();
        Stopwatch LassoTimer = new Stopwatch();
        public override void LoadSettings()
        {
            Settings.Add(new Setting("Game Client Language", new List<string>()
            {
                "English",
                "Deutsch",
                "Español",
                "Français",
                "Italiano",
                "Português Brasileiro",
                "Русский",
                "한국어",
                "简体中文"
            }, "English"));
            Settings.Add(new Setting("Kick at milliseconds remaining", 100, 1500, 1000));
            Settings.Add(new Setting("Kick channels after milliseconds", 50, 2000, 500));
            Settings.Add(new Setting("Minimum delay", 50, 2000, 500));
            List<string> ClassList = new List<string>(new string[] { "Shaman", "Death Knight", "Guardian Druid", "Monk", "Mage", "Hunter", "Shadow Priest", "Rogue", "Demon Hunter", "Warrior", "Paladin", "Warlock", "Evoker" });
            Settings.Add(new Setting("Class", ClassList, "Monk"));
            Settings.Add(new Setting("Kick from OoC?", true));
            Settings.Add(new Setting("Use CC to interrupt?", true));
            Settings.Add(new Setting("Kick Mousover targets?", true));
            Settings.Add(new Setting("Use Raid Kick list?", false));

        }
        List<string> Interrupts = new List<string>();
        List<string> CCInterrupts = new List<string>();
        string Class = "";
        bool KickArena = true;
        bool OOCKicks = true;
        bool UseCC = true;
        int KickValue = 0;
        int KickChannelsAfter = 0;
        int MinimumDelay = 0;
        Enemy Target = new Enemy("target");
        Enemy Focus = new Enemy("focus");
        List<Enemy> Enemies = new List<Enemy>();
        public override void Initialize()
        {
            if (authorized)
            {
            }
            Language = GetDropDown("Game Client Language");
            Class = GetDropDown("Class");
            OOCKicks = GetCheckBox("Kick from OoC?");
            UseCC = GetCheckBox("Use CC to interrupt?");
            Enemies.Add(Target);
            Enemies.Add(Focus);
            Aimsharp.PrintMessage("Aya's M+/Raid Kicks Plugin");
            Aimsharp.PrintMessage("Automated kicking for your target and focus");
            Aimsharp.PrintMessage("Do not use this together with any other Kicks plugin!");
            Aimsharp.PrintMessage("Use this macro to hold your kicks for a number of seconds: /xxxxx SaveKicks #");
            Aimsharp.PrintMessage("For example: /xxxxx SaveKicks 5");
            Aimsharp.PrintMessage("will make the bot not kick anything for the next 5 seconds.");
            if (Class == "Hunter")
            {
                Interrupts.Add(CounterShot_SpellName());
                Interrupts.Add(Muzzle_SpellName());
                if (UseCC)
                {
                    CCInterrupts.Add(Intimidation_SpellName());
                }
            }
            if (Class == "Rogue")
            {
                Interrupts.Add(Kick_SpellName());
				if (UseCC)
                {
                    CCInterrupts.Add(Gouge_SpellName());
					CCInterrupts.Add(KidneyShot_SpellName());
					CCInterrupts.Add(Blind_SpellName());
				}
            }
            if (Class == "Shadow Priest")
            {
                Interrupts.Add(Silence_SpellName());
            }
            if (Class == "Demon Hunter")
            {
                Interrupts.Add(Disrupt_SpellName());
				if (UseCC)
                {
                    CCInterrupts.Add(ChaosNova_SpellName());
                    CCInterrupts.Add(FelEruption_SpellName());
					CCInterrupts.Add(Metamorphosis_SpellName());
            }
            }
            if (Class == "Shaman")
            {
                Interrupts.Add(Windshear_SpellName());
                if (UseCC)
                {
                    CCInterrupts.Add(CapacitorTotem_SpellName());
                }
            }
            if (Class == "Paladin")
            {
                Interrupts.Add(Rebuke_SpellName());
                Interrupts.Add(AvengersShield_SpellName());
				if (UseCC)
                {
                    CCInterrupts.Add(HammerofJustice_SpellName());
                }
            }
            if (Class == "Death Knight")
            {
                Interrupts.Add(MindFreeze_SpellName());
                if (UseCC)
                {
                    CCInterrupts.Add(Asphyxiate_SpellName());
                    CCInterrupts.Add(DeathGrip_SpellName());
					CCInterrupts.Add(Strangulate_SpellName());
					CCInterrupts.Add(Gnaw_SpellName());
                }
            }
            if (Class == "Guardian Druid")
            {
                Interrupts.Add(SkullBash_SpellName());
                Interrupts.Add(SolarBeam_SpellName());
                if (UseCC)
                {
                    CCInterrupts.Add(MightyBash_SpellName());
					CCInterrupts.Add(FeralCharge_SpellName());
				}
            }
            if (Class == "Warlock")
            {
                Interrupts.Add(SpellLock_SpellName());
				Interrupts.Add(OpticalBlast_SpellName());
            }
            if (Class == "Mage")
            {
                Interrupts.Add(Counterspell_SpellName());
            }
            if (Class == "Monk")
            {
                Interrupts.Add(SpearHandStrike_SpellName());
                if (UseCC)
                {
                    CCInterrupts.Add(Paralysis_SpellName());
                    CCInterrupts.Add(LegSweep_SpellName());
                }
            }
            if (Class == "Warrior")
            {
                Interrupts.Add(Pummel_SpellName());
				if (UseCC)
                {
                    CCInterrupts.Add(StormBolt_SpellName());
					CCInterrupts.Add(IntimidatingShout_SpellName());           
                }
            }
            if (Class == "Evoker")
            {
                Interrupts.Add(Quell_SpellName());
            }
            foreach (string Interrupt in Interrupts)
            {
                Spellbook.Add(Interrupt);
                Macros.Add(Interrupt + "focus", "/cast [@focus] " + Interrupt);
                Macros.Add(Interrupt + "mouseover", "/cast [@mouseover] " + Interrupt);
            }
            foreach (string CCInterrupt in CCInterrupts)
            {
                Spellbook.Add(CCInterrupt);
                Macros.Add(CCInterrupt + "focus", "/cast [@focus] " + CCInterrupt);
                Macros.Add(CCInterrupt + "mouseover", "/cast [@mouseover] " + CCInterrupt);
            }
            foreach (string immune in immunes)
            {
                Buffs.Add(immune);
            }
            foreach (string spell_immune in spell_immunes)
            {
                Buffs.Add(spell_immune);
            }
            foreach (string physical_immune in physical_immunes)
            {
                Buffs.Add(physical_immune);
            }
            string SpellsToKickNormRaid = "{360176, 366392, 364030, 360259, 362383, 361913, 350342, 350286, 350283, 351779, 357144, 348428, 352141, 355540, 325590, 337110, 325590, 328254, 333002, 337110, 333002, 331550, 337110," +
										   "325590, 328254, 325665, 344776, 337865, 333145, 342288}";
            string SpellsToKickCCRaid = "{365008, 364073,334708, 328248}";
            string SpellsToKickNormMplus = "{332707, 332666, 332706, 332612, 332084, 321764, 320008, 332608, 328740, 323064, 332605, 328707, 333875, 334076, 332196, 331379, 332234, 332705, 325700, 326607, 323552, 323538, 325876," +
                                            "338003, 328322, 322938, 324914, 324776, 326046, 340544, 337235, 337251, 337253, 322450, 321828, 322767, 323057, 335143, 334748, 330784, 324293, 338353, 323190, 327130, 328667," +
                                            "320571, 340210, 328180, 321999, 328094, 328016, 329239, 329917, 327995, 328002,328094, 322358, 328534, 328475, 319654, 322433, 321038, 334653, 335305, 336277, 326952, 326836, 326712," +
                                            "326837, 320861, 321105, 327413, 317936, 317963, 328295, 328137, 328331, 327648, 317959, 327481, 317661, 341902, 330784, 333231, 320300, 320120, 341969, 330703, 342139, 330562, 330810," +
                                            "330868, 341771, 330875, 342675, 323190, 263085, 294526, 330438, 297018, 252057, 252063, 328869, 297310, 330477, 332165, 329930, 294517, 296839, 294165, 330118, 183345, 297024, 258935," +
                                            "277040, 242391, 330573, 326399, 345554, 327461, 330479, 310392, 184381, 334538, 329322, 330755, 295929, 318995, 167012, 354493, 352215, 304946, 242733, 355888, 355930, 355934," +
                                            "354297, 356324, 356404, 356407, 355641, 353835, 347775, 347903, 350922, 357188, 354297, 355225, 355234, 357284, 357260, 351119, 352347, 356843, 355737, 358967, 366566, 300764, 300650," +
                                            "300171, 299588, 300414, 300514, 301689, 301088, 293729, 228255, 228239, 228025, 227987, 228011, 228019, 227420, 227543, 227341, 227917, 232115, 228280, 228277, 226316," +
											"228625, 227823, 227800, 227545, 227616, 227542, 228606, 229307, 227592, 229714, 229083, 230084, 166335, 165122, 178155, 228254, 228700, 373747, 374743, 226344, 228278, 241808, 284219," +
                                            "178154, 227776, 388392, 396812, 388392, 396812, 377389, 396640, 387843, 387955, 387910, 375602, 387564, 386546, 389804, 377488, 382249, 367500, 377950, 385029, 373804, 381770, 374544, " +
                                            "374066, 374339, 374045, 374080, 389443, 395694, 374563, 385141, 374706, 375384, 375950, 377348, 377402, 387618, 378282, 372615, 395427, 372538, 384161, 382795, 384365, 386024, 387411, " + 
                                            "387606, 376725, 384808, 373395, 373017, 392398, 392451, 385310, 375602, 386546, 387564, 373932, 386546, 369675, 369674, 369823, 369603, 369399, 369400, 211401, 211464, 207980, 208165, " +
                                            "207881, 198595, 198959, 192288, 199726, 198750, 152818, 156776, 156722, 398206, 156718, 153524, 397888, 114646, 395859, 396073, 397914}";

            string SpellsToKickCCMplus = "{332329, 332671, 332156, 334664, 326450, 325701, 331743, 322569, 324987, 325021, 320822, 321807, 321780, 320822, 334747, 338022, 328400, 328177, 336451, 328429, 328338, 329163, 321935, 324609, " +
                                            "300777, 330586, 333540, 330532, 330694, 295985, 335528, 330822, 304254, 332181, 297966, 358328, 241687, 355915, 356031, 355057, 355132, 322169, 228279, 166398, 228603, 241828, 293827, 300436, " +
                                            "300087, 163966, 373570, 383823, 387135, 153153}";

            string InRangeItem = "0";
            if (Class == "Evoker" || Class == "Monk" || Class == "Guardian Druid" || Class == "Death Knight" || Class == "Rogue" || Class == "Demon Hunter" || Class == "Warrior" || Class == "Paladin")
            {
                InRangeItem = "32321";
            }
            if (Class == "Mage" || Class == "Shaman" || Class == "Hunter" || Class == "Shadow Priest" || Class == "Warlock")
            {
                InRangeItem = "18904";
            }
            string MOCastRemaining = GetSlider("Kick at milliseconds remaining").ToString();
            string MOChannelRemaining = GetSlider("Kick channels after milliseconds").ToString();
            CustomFunctions.Add("ShouldKickMONormMplus",
                "local ShouldKickMO = 0" + "\n local WhiteList = " + SpellsToKickNormMplus +
                "\nif UnitExists(\"mouseover\") then\n" +
                    "local CAname, CAtext, CAtexture, CAstartTimeMS, CAendTimeMS, CAisTradeSkill, CAcastID, CAnotInterruptible, CAspellId = UnitCastingInfo(\"mouseover\")\n" +
                    "local name, text, texture, startTimeMS, endTimeMS, isTradeSkill, notInterruptible, spellId = UnitChannelInfo(\"mouseover\")\n" +
                    "if IsItemInRange(" + InRangeItem + ", \"mouseover\") and UnitCanAttack(\"player\", \"mouseover\") == true and UnitIsDead(\"mouseover\") ~= true then\n" +
                        "if CAspellID ~= nil or spellID ~= 0 then\n" +
                            "for _, k in pairs(WhiteList) do\n" +
                                "if k == CAspellId then\n" +
                                    "if CAendTimeMS - CAstartTimeMS >= " + MOCastRemaining + " and CAnotInterruptible == false then\n" +
                                        "ShouldKickMO = 1\n" +
                                    "end\n" +
                                "else if k == spellID then\n" +
                                    "if (GetTime() * 1000) - startTimeMS >= " + MOChannelRemaining + " and CAnotInterruptible == false then\n" +
                                        "ShouldKickMO = 1\n" +
                                    "end\n" +
                                "end\n" +
                            "end\n" +
                        "end\n" +
                    "end\n" +
                "end\n" +
            "end\n" +
            "return ShouldKickMO");
            CustomFunctions.Add("ShouldKickMOCCMplus",
                "local ShouldKickMO = 0" + "\n local WhiteList = " + SpellsToKickCCMplus +
                "\nif UnitExists(\"mouseover\") then\n" +
                    "local CAname, CAtext, CAtexture, CAstartTimeMS, CAendTimeMS, CAisTradeSkill, CAcastID, CAnotInterruptible, CAspellId = UnitCastingInfo(\"mouseover\")\n" +
                    "local name, text, texture, startTimeMS, endTimeMS, isTradeSkill, notInterruptible, spellId = UnitChannelInfo(\"mouseover\")\n" +
                    "if IsItemInRange(" + InRangeItem + ", \"mouseover\") and UnitCanAttack(\"player\", \"mouseover\") == true and UnitIsDead(\"mouseover\") ~= true then\n" +
                        "if CAspellID ~= nil or spellID ~= 0 then\n" +
                            "for _, k in pairs(WhiteList) do\n" +
                                "if k == CAspellId then\n" +
                                    "if CAendTimeMS - CAstartTimeMS >= " + MOCastRemaining + " then\n" +
                                        "ShouldKickMO = 1\n" +
                                    "end\n" +
                                "else if k == spellID then\n" +
                                    "if (GetTime() * 1000) - startTimeMS >= " + MOChannelRemaining + " then\n" +
                                        "ShouldKickMO = 1\n" +
                                    "end\n" +
                                "end\n" +
                            "end\n" +
                        "end\n" +
                    "end\n" +
                "end\n" +
            "end\n" +
            "return ShouldKickMO");
            CustomFunctions.Add("ShouldKickMORaid",
                "local ShouldKickMO = 0" + "\n local WhiteList = " + SpellsToKickNormRaid +
                "\nif UnitExists(\"mouseover\") then\n" +
                    "local CAname, CAtext, CAtexture, CAstartTimeMS, CAendTimeMS, CAisTradeSkill, CAcastID, CAnotInterruptible, CAspellId = UnitCastingInfo(\"mouseover\")\n" +
                    "local name, text, texture, startTimeMS, endTimeMS, isTradeSkill, notInterruptible, spellId = UnitChannelInfo(\"mouseover\")\n" +
                    "if IsItemInRange(" + InRangeItem + ", \"mouseover\") and UnitCanAttack(\"player\", \"mouseover\") == true and UnitIsDead(\"mouseover\") ~= true then\n" +
                        "if CAspellID ~= nil or spellID ~= 0 then\n" +
                            "for _, k in pairs(WhiteList) do\n" +
                                "if k == CAspellId then\n" +
                                    "if CAendTimeMS - CAstartTimeMS >= " + MOCastRemaining + " and CAnotInterruptible == false then\n" +
                                        "ShouldKickMO = 1\n" +
                                    "end\n" +
                                "else if k == spellID then\n" +
                                    "if (GetTime() * 1000) - startTimeMS >= " + MOChannelRemaining + " and CAnotInterruptible == false then\n" +
                                        "ShouldKickMO = 1\n" +
                                    "end\n" +
                                "end\n" +
                            "end\n" +
                        "end\n" +
                    "end\n" +
                "end\n" +
            "end\n" +
            "return ShouldKickMO");
            CustomFunctions.Add("ShouldKickMOCCRaid",
                "local ShouldKickMO = 0" + "\n local WhiteList = " + SpellsToKickCCRaid +
                "\nif UnitExists(\"mouseover\") then\n" +
                    "local CAname, CAtext, CAtexture, CAstartTimeMS, CAendTimeMS, CAisTradeSkill, CAcastID, CAnotInterruptible, CAspellId = UnitCastingInfo(\"mouseover\")\n" +
                    "local name, text, texture, startTimeMS, endTimeMS, isTradeSkill, notInterruptible, spellId = UnitChannelInfo(\"mouseover\")\n" +
                    "if IsItemInRange(" + InRangeItem + ", \"mouseover\") and UnitCanAttack(\"player\", \"mouseover\") == true and UnitIsDead(\"mouseover\") ~= true then\n" +
                        "if CAspellID ~= nil or spellID ~= 0 then\n" +
                            "for _, k in pairs(WhiteList) do\n" +
                                "if k == CAspellId then\n" +
                                    "if CAendTimeMS - CAstartTimeMS >= " + MOCastRemaining + " then\n" +
                                        "ShouldKickMO = 1\n" +
                                    "end\n" +
                                "else if k == spellID then\n" +
                                    "if (GetTime() * 1000) - startTimeMS >= " + MOChannelRemaining + " then\n" +
                                        "ShouldKickMO = 1\n" +
                                    "end\n" +
                                "end\n" +
                            "end\n" +
                        "end\n" +
                    "end\n" +
                "end\n" +
            "end\n" +
            "return ShouldKickMO");
            CustomCommands.Add("SaveKicks");
}
        int[] Raid =
        { 
        //Sepulcher of the First Ones 
        360176, //Blast 
        366392, //Searing Ablation 
        364030, //Debilitating Ray 
        360259, //Gloom Bolt 
        362383, //Anima Bolt 
        365008, //Psychic Terror (CC to interrupt) 
        361913, //Manifest Shadows 
        364073, //Degenerate (CC to interrupt) 
        //Sanctum of Domination 
        350342, //Formless Mass 
        350286, //Song of Dissolution 
        350283, //Soulful Blast 
        351779, //Agonizing Nova 
        357144, //Despair 
        348428, //Piercing Wall 
        352141, //Banshees Cry 
        355540, //Ruin 
        325590, //Sunking 
        337110, //Council Frida 
        325590, //Scorful Blast 
        328254, //Shattering Ruby 
      	333002, //Vulgar Brand 
        337110, //Dreadbolt Volley
		//Castle Nathria
		333002, //Vulgar Brand
		331550, //Condemn
		337110, //Dreadbolt Volley
		334708, //Deathly Roar (CC to interrupt)
		325590, //Scornful Blast
		328248, //Door of Shadows (CC to interrupt)
		328254, //Shattering Ruby
		325665, //Soul Infusion
		344776, //Vengeful Wail
		337865, //Unleashed Pyroclasm
		333145, //Return to Stone
		342288, //Sins and Suffering
        };
        int[] MythicPlus =
        { 
        //Algeth'ar Academy
        388392, //Monotonous Lecture
        396812, //Mystic Blast
        377389, //Call of the Flock
        396640, //Healing Touch
        387843, //Astral Bomb
		387955, //Celestial Shield
		387910, //Astral Whirlwind

        //Azure Vault
        375602, //Erratic Growth
        387564, //Mystic Vapors
        386546, //Waking Bane
        389804, //Heavy Tome
        377488, //Icy Bindings

        //Brackenhide
        382249, //Earth Bolt
        367500, //Hideous Cackle
        377950, //Greater Healing Rapids
        385029, //Screech
        373804, //Touch of Decay
        381770, //Gushing Ooze
        374544, //Burst of Decay

        //Halls of Infusion
        374066, //Earth Shield
        374339, //Demoralizing Shout
        374045, //Expulse
        374080, //Blasting Gust
        389443, //Purifying Blast
        395694, //Elemental Focus
        374563, //Dazzle
        385141, //Thunderstorm
        374706, //Pyretic Burst
        375384, //Rumbling Earth
        375950, //Ice Shards
        377348, //Tidal Divergence
        377402, //Aqueous Barrier
        387618, //Infuse

        //Neltharus
        378282, //Molten Core
        372615, //Ember Reach
        395427, //Burning Roar
        372538, //Melt
        384161, //Mote of Combustion
        382795, //Molten Barrier

        //Nokhud
        384365, //Disruptive Shout
        386024, //Tempest
        387411, //Death Bolt Volley
        387606, //Dominate
        376725, //Storm Bolt
		384808, //Guardian Wind
		383823, //Rally the Clan (CC to interrupt)
		387135, //Arcing Strike (CC to interrupt)
		373395, //Bloodcurdling Shout

        //RLP
        373017, //Roaring Blaze
        392398, //Crackling Detonation
        392451, //Flashfire
        385310, //Lightning Bolt
		375602, //Erratic Growth
		386546, //Waking Bane
		387564, //Mystic Vapors
		373932, //Illusionary Bolt
		386546, //Waking Bane

        //Uldaman
        369675, //Chain Lightning
        369674, //Stone Spike
        369823, //Spiked Carapace
        369603, //Defensive Bulwark
        369399, //Stone Bolt
        369400, //Earthen Ward

        //Court of Stars
		211401, //Drifting Embers
		211464, //Fel Detonation
		207980, //Disintegration Beam
		208165, //Withering Soul
		207881, //Infernal Eruption

		//Halls of Valor
		198595, //Thunderous Bolt
		198959, //Etch
		192288, //Searing Light
		199726, //Unruly Yell
		198750, // Surge

		//Shadowmoon Burial Grounds
		152818, //Shadow Mend
		153153, //Dark Communion (CC to interrupt)
		156776, //Rending Voidlash
		156722, //Void Bolt
		398206, //Death Blast
		156718, //Necrotic Burst
		153524, //Plague Spit

		//Temple of the Jade Serpent
		397888, //Hydrolance
		114646, //Haunting Gaze
		395859, //Haunting Scream
		396073, //Cat Nap
		397914, //Defiling Mist

        //De Other Side 
        332329, //Devoted Sacrifice (CC to interrupt) 
        332671, //Bladestorm (CC to interrupt) 
        332707, //Shadow Word Pain 
        332666, //Renew 
        332706, //Heal 
        332612, //Healing Wave 
        332084, //Self-Cleaning Cycle 
        321764, //Bark Armor 
        320008, //Frostbolt 
        332608, //Lightning Discharge 
        328740, //Dark Lotus 
        323064, //Blood Barrage 
        332605, //Hex 
        328707, //Scribe 
        333875, //Deaths Embrace 
        334076, //Shadowcore 
        332196, //Discharge 
        331379, //Lubricate 
        332234, //Essential Oil 
        332705, //Smite 
        332156, //Spinning Up (CC to interrupt) 
        334664, //Frightened Cries (CC to interrupt) 
        //Halls of Attonement 
        326450, //Loyal Beasts (CC to interrupt) 
        325700, //Collect Sins 
        325701, //Siphon Life (CC to interrupt) 
        326607, //Turn to Stone 
        323552, //Volley of Power 
        323538, //Bolt of Power 
        325876, //Curse of Obliteration 
        338003, //Wicked Bolt 
        328322, //Villainous Bolt 
        //Mists of Tirna Scithe 
        322938, //Harvest Essence 
        324914, //Nourish the Forest 
        324776, //Bramblethorn Coat 
        326046, //Stimulate Resistance 
        340544, //Stimulate Regeneration 
        337235, //Parasitic Pacification 
        337251, //Parasitic Incapacitation 
        337253, //Parasitic Domination 
        322450, //Consumption 
        321828, //Patty Cake 
        322767, //Spirit Bolt 
        331743, //Bucking Rampage (CC to interrupt) 
        322569, //Hand of Thros (CC to interrupt) 
        323057, //Spirit Bolt 
        324987, //Mistveil Bite (CC to interrupt) 
        325021, //Mistveil Tear (CC to interrupt) 
        //Necrotic Wake 
        335143, //Bonemend 
        334748, //Drain Fluids 
        330784, //Necrotic Bolt 
        320822, //Final Bargain (CC to interrupt) 
        324293, //Rasping Scream 
        338353, //Goresplatter 
        323190, //Meat Shield 
        327130, //Repair Flesh 
        328667, //Frostbolt Volley 
        321807, //Boneflay (CC to interrupt) 
        321780, //Animate Dead (CC to interrupt) 
        320822, //Final Bargain (CC to interrupt) 
        334747, //Throw Flesh (CC to interrupt) 
        320571, //Shadow Well 
        338022, //Leap (CC to interrupt) 
        //Plaguefall 
        328400, //Stealthlings (CC to interrupt) 
        328177, //Fungistorm ( CC to interrupt) 
        336451, //Bulwark of Maldraxxus (CC to interrupt) 
        328429, //Crushing Embrace (CC to interrupt) 
        340210, //Corrosive Gunk 
        328180, //Gripping Infection 
        321999, //Viral Globs 
        328094, //Pestilence Bolt 
        328016, //Wonder Grow 
        328338, //Call Venomfang (CC to interrupt) 
        329239, //Creepy Crawlers 
        329917, //Binding Fungus 
        327995, //Doom Shroom 
        328002, //Hurl Spores 
        328094, //Pestilence Bolt 
        322358, //Burning Strain 
        328534, //Vile Spit 
        328475, //Enveloping Webbing 
        329163, //Ambush (CC to interrupt) 
        321935, //Withering Filth (CC to interrupt) 
        //Sanguine Depths 
        319654, //Hungering Drain 
        322433, //Stoneskin 
        321038, //Wrack Soul 
        334653, //Engorge 
        335305, //Barbed Shackles 
        336277, //Explosive Anger 
        326952, //Fiery Cantrip 
        326836, //Curse of Suppression 
        326712, //Dark Bolt 
        326837, //Gloom Burst 
        324609, //Animate Weapon (CC to interrupt) 
        320861, //Drain Essence 
        321105, //Sap Lifeblood 
        322169, //Growing Mistrust (CC to interrupt) 
        //Spires of Ascension  
        327413, //Rebellious Fist 
        317936, //Forsworn Doctrine 
        317963, //Burden of Knowledge 
        328295, //Greater Mending 
        328137, //Dark Pulse 
        328331, //Forced Confession 
        327648, //Internal Strife 
        317959, //Dark Lash 
        327481, //Dark Lance 
        317661, //Insidious Venom 
        //Theater of Pain 
        341902, //Unholy Fervor 
        330784, //Necrotic Bolt 
        333231, //Searing Death 
        320300, //Necromantic Bolt 
        320120, //Plague Bolt 
        341969, //Withering Discharge 
        330703, //Decaying Filth 
        342139, //Battle Trance 
        330562, //Demoralizing Shout 
        330810, //Bind Soul 
        330868, //Necrotic Bolt Volley 
        341771, //Grave Spike 
        330875, //Spirit Frost 
        342675, //Bone Spear 
        330586, //Devour Flesh (CC to interrupt) 
        323190, //Meat Shield 
        333540, //Opportunity Strikes (CC to interrupt) 
        330532, //Jagged Quarrel (CC to interrupt) 
        330694, //Leaping Thrash (CC to interrupt) 
        //Torgast 
        263085, //Terrifying Roar 
        294526, //Curse of Frailty 
        330438, //Fearsome Howl 
        297018, //Fearsome Howl 
        252057, //Cripping Burst 
        252063, //Dread Plague 
        328869, //Dark Bolt Volley 
        297310, //Steal Vitality 
        330477, //Prophecy of Death 
        332165, //Fearsome Shriek 
        329930, //Terrifying Screeh 
        294517, //Phasing Roar 
        296839, //Dearth Blast 
        294165, //Accursed Strength 
        330118, //Withering Roar 
        295985, //Ground Crush (CC to interrupt) 
        335528, //Inferno (CC to interrupt) 
        183345, //Shadow Bolt 
        297024, //Soul Echo 
        258935, //Inner Flames 
        277040, //Soul of Mist 
        242391, //Terror 
        330573, //Bounty of The Forest 
        326399, //Crush 
        345554, //Stygian Shield 
        327461, //Meat Hook 
        330479, //Gunk 
        310392, //Intimidating Presence 
        184381, //Interrupting Slam 
        334538, //Deaden Magic 
        329322, //Soul Bolt 
        330755, //Focused Blast 
        330822, //Ocular Beam (CC to interrupt) 
        295929, //Rats 
        318995, //Deafening Howl 
        167012, //Incorporeal 
        304254, //Devour Soul (CC to interrupt) 
        332181, //Mass Devour (CC to interrupt) 
        297966, //Devour Obleron Armaments (CC to interrupt) 
        354493, //Soul Breaker 
        352215, //Cries of the Tormented 
        358328, //Tortured Stomp (CC to interrupt) 
        304946, //Shadow Rip 
        //Mage Tower – Hunter 
        242733, //Fel Burst 
        241687, //Sonic Scream (CC to interrupt) 
        //Tazavesh Streets of Wonder 
        355888, //Hard Light Baton 
        355930, //Spark Burn 
        355934, //Hard Light Barrier 
        354297, //Hyperlight Bolt 
        356324, //Empowered Glyph of Restraint 
        355915, //Glyph of Restraint (CC to interrupt) 
        356031, //Stasis Beam (CC to interrupt) 
        356404, //Lava Breath 
        356407, //Ancient Dread 
        355641, //Scintillate 
        353835, //Suppression 
        347775, //Spam Filter 
        347903, //Junk Mail 
        350922, //Menacing Shout 
        357188, //Double Technique 
        //Tazavesh Soleah’s Gambit 
        354297, //Hyper Light Bolt 
        355057, //Cry of Mrrggllrrgg (CC to interrupt) 
        355225, //Water Bolt 
        355234, //Volatile Pufferfish 
        357284, //Reinvigorate 
        357260, //Unstable Rift 
        351119, //Shuriken Blitz 
        352347, //Valorous Bolt 
        355132, //Invigorating Fish Stick (CC to interrupt) 
        356843, //Brackish Bolt
        //Affixes Season 4
        373747, //Blood Siphon
        373570, //Hypnosis
        //Return to Karazhan: Upper
        228254, //Soul Leech
        228239, //Terrifying Wail
        228700, //Arcane Barrage
        227592, //Frost Bite
        229083, //Burning Blast
        374743, //Fel Fireball        
        //Return to Karazhan: Lower
        228025, //Heat Wave
        227917, //Poetry Slam (CC to interrupt)
        232115, //Firelands Portal
        226344, //Shadow Bolt
        227616, //Empowered Arms
        228603, //Charge (CC to interrupt)
        241828, //Trampling Stomp (CC to interrupt)
        228278, //Demoralizing Shout
        241808, //Shadow bolt Volley
        227823, //Holy Wrath
        227800, //Holy Shock
        228606, //Healing Touch
        227776, //Magic Magnificent
        227341, //Flashy Bolt
        //Operation: Mechagon - Workshop
        301088, //Detonate
        293827, //Giga-Wallop (CC to interrupt) 
        //Operation: Mechagon - Junkyard
        300436, //Grasping Hex (CC to interrupt)
        300764, //Slimebolt
        300777, //Slimewave (CC to interrupt)
        284219, //Shrink
        300650, //Suffocating Smog
        300171, //Repair Protocol
        300087, //Repair (CC to interrupt)
        299588, //Overclock
        300414, //Enrage
        //Grimriail Depot
        166335, //Storm Shield
        163966, //Activating (CC to interrupt)
        //Iron Docks
        178154, //Acid Spit
        165122, //Blood Bolt

        };
        int RandomDelay = 0;
        public override bool CombatTick()
        {
            if (authorized)
            {
                foreach (Enemy t in Enemies)
                {
                    t.Update();
                }
                if (!RngTimer.IsRunning)
                {
                    RngTimer.Restart();
                    RandomDelay = rng.Next(0, 500);
                }
                if (RngTimer.ElapsedMilliseconds > 10000)
                {
                    RngTimer.Restart();
                    RandomDelay = rng.Next(0, 500);
                }
                KickValue = GetSlider("Kick at milliseconds remaining");
                KickChannelsAfter = GetSlider("Kick channels after milliseconds");
                MinimumDelay = GetSlider("Minimum delay");
                bool IAmChanneling = Aimsharp.IsChanneling("player");
                int GCD = Aimsharp.GCD();
                float Haste = Aimsharp.Haste() / 100f;
                bool LineOfSighted = Aimsharp.LineOfSighted();
                bool NoKicks = Aimsharp.IsCustomCodeOn("SaveKicks");
                bool InRange = false;
                bool ShouldKickMOMplus = false;
                bool ShouldKickMOCCMplus = false;
                bool ShouldKickMORaid = false;
                bool ShouldKickMOCCRaid = false;

                if (GetCheckBox("Kick Mousover targets?"))
                {
                    ShouldKickMOMplus = Aimsharp.CustomFunction("ShouldKickMONormMplus") == 1;
                    if (GetCheckBox("Use CC to interrupt?"))
                    {
                        ShouldKickMOMplus = Aimsharp.CustomFunction("ShouldKickMOCCMplus") == 1;
                        if (GetCheckBox("Use Raid Kick list?"))
                        {
                            ShouldKickMOCCRaid = Aimsharp.CustomFunction("ShouldKickMOCCRaid") == 1;
                        }
                    }
                    if (GetCheckBox("Use Raid Kick list?"))
                    {
                        ShouldKickMORaid = Aimsharp.CustomFunction("ShouldKickMORaid") == 1;
                    }
                }

                if (Class == "Monk" || Class == "Guardian Druid" || Class == "Death Knight" || Class == "Rogue" || Class == "Demon Hunter" || Class == "Warrior")
                {
                    InRange = Aimsharp.Range("target") <= 10;
                }
                if (Class == "Mage" || Class == "Shaman" || Class == "Hunter" || Class == "Shadow Priest")
                {
                    InRange = Aimsharp.Range("target") <= 35;
                }
                KickValue = KickValue + RandomDelay;
                KickChannelsAfter = KickChannelsAfter + RandomDelay;
                if (IAmChanneling || LineOfSighted)
                    return false;
                if (!NoKicks)
                {
                    foreach (string Interrupt in Interrupts)
                    {
                        foreach (Enemy t in Enemies)
                        {
                            if (Aimsharp.CanCast(Interrupt, "target") && InRange)
                            {
                                //Raid list
                                if ((GetCheckBox("Use Raid Kick list?")) && (Raid.Contains(t.CastingID) && (!t.IsChanneling && t.CastingRemaining < KickValue || t.IsChanneling && t.CastingElapsed > KickChannelsAfter) && t.IsInterruptable && t.CastingElapsed > MinimumDelay))
                                {
                                    if (t.Unit == "target")
                                    {
                                        Aimsharp.Cast(Interrupt, true);
                                        return true;
                                    }
                                    else
                                    {
                                        Aimsharp.Cast(Interrupt + t.Unit, true);
                                        return true;
                                    }
                                }
                                //M+ list
                                if (MythicPlus.Contains(t.CastingID) && (!t.IsChanneling && t.CastingRemaining < KickValue || t.IsChanneling && t.CastingElapsed > KickChannelsAfter) && t.IsInterruptable && t.CastingElapsed > MinimumDelay)
                                {
                                    if (t.Unit == "target")
                                    {
                                        Aimsharp.Cast(Interrupt, true);
                                        return true;
                                    }
                                    else
                                    {
                                        Aimsharp.Cast(Interrupt + t.Unit, true);
                                        return true;
                                    }
                                }
                            }
                        }
                        if (ShouldKickMOMplus && Aimsharp.CanCast(Interrupt, "target"))
                        {
                            Aimsharp.Cast(Interrupt + "mouseover", true);
                            return true;
                        }
                        if (ShouldKickMORaid && Aimsharp.CanCast(Interrupt, "target"))
                        {
                            Aimsharp.Cast(Interrupt + "mouseover", true);
                            return true;
                        }
                    }
                    foreach (string CCInterrupt in CCInterrupts)
                    {
                        foreach (Enemy t in Enemies)
                        {
                            if (Aimsharp.CanCast(CCInterrupt, "target") && InRange)
                            {
                                //kick raid spells
                                if ((GetCheckBox("Use Raid Kick list?")) && (Raid.Contains(t.CastingID) && (!t.IsChanneling && t.CastingRemaining < KickValue || t.IsChanneling && t.CastingElapsed > KickChannelsAfter) && t.CastingElapsed > MinimumDelay))
                                {
                                    if (t.Unit == "target")
                                    {
                                        Aimsharp.Cast(CCInterrupt, true);
                                        return true;
                                    }
                                    else
                                    {
                                        Aimsharp.Cast(CCInterrupt + t.Unit, true);
                                        return true;
                                    }
                                }
                                //kick mplus spells
                                if (MythicPlus.Contains(t.CastingID) && (!t.IsChanneling && t.CastingRemaining < KickValue || t.IsChanneling && t.CastingElapsed > KickChannelsAfter) && t.CastingElapsed > MinimumDelay)
                                {
                                    if (t.Unit == "target")
                                    {
                                        Aimsharp.Cast(CCInterrupt, true);
                                        return true;
                                    }
                                    else
                                    {
                                        Aimsharp.Cast(CCInterrupt + t.Unit, true);
                                        return true;
                                    }
                                }
                            }
                        }
                        if (ShouldKickMOCCMplus && Aimsharp.CanCast(CCInterrupt, "target"))
                        {
                            Aimsharp.Cast(CCInterrupt + "mouseover", true);
                            return true;
                        }
                        if (ShouldKickMOCCRaid && Aimsharp.CanCast(CCInterrupt, "target"))
                        {
                            Aimsharp.Cast(CCInterrupt + "mouseover", true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public override bool OutOfCombatTick()
        {
            if (authorized)
            {
                if (OOCKicks)
                    return CombatTick();
            }
            return false;
        }
    }
}
