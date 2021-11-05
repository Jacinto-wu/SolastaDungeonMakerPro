--
-- ALWAYS CHECK FOR actors.Count BEFORE INDEXING IT
--

--[[
Actor.Name
Actor.SurName
Actor.Class
Actor.Race
Actor.SubRace
Actor.HitPoints
Actor.Lvl
Actor.Str
Actor.Dex
Actor.Con
Actor.Int
Actor.Wis
Actor.Cha
Actor.Conditions
Actor.ConditionsByCategory
Actor.CanCastSpell
Actor.CanCastAnyRitualSpell
Actor.Invisible (get/set)
Actor.InfiniteActions (get/set)
Actor.HasItem(itemDefinition)
Actor.GrantItem(itemDefinition, quantity)
Actor.LoseItem(itemDefinition, removeAllInstances)
]]

--
-- GLOBALS
--
-- party is List<Actor>
-- actors is List<Actor>
-- characters is List<GameLocationCharacter>
-- 

--
-- name is the gadget unique name
-- params is class FunctorParametersDescription
--
function on_activate(name, params)
            
    log('on_activate ' .. name)
    return true
end

function on_deactivate(name, params)

    log('on_deactivate ' .. name)
    return true
end

function on_enable(name, params)

    log('on_enable ' .. name)
    return true
end

function on_disable(name, params)

    log('on_disable ' .. name)
    return true
end

function on_bind_items(name, params)

    log('on_bind_items ' .. name)
    return true
end

function on_bind_merchant(name, params)

    log('on_bind_merchant ' .. name)
    return true
end

function on_display_lore(name, params)
    
    log('on_display_lore ' .. name)
    return true
end

function on_environment_effect(name, params)

    log('on_environment_effect ' .. name)
    return true
end   

function on_force_banter_line(name, params)

    log('on_force_banter_line ' .. name)
    return true
end

function on_grant_experience(name, params)

    log('on_grant_experience ' .. name)
    return true
end

function on_inventory_loot(name, params)

    log('on_inventory_loot ' .. name)
    return true
end

function on_open_merchant(name, params)

    log('on_open_merchant ' .. name)
    return true
end

function on_quit_location(name, params)

    log('on_quit_location ' .. name)
    return true
end

function on_remove_monsters(name, params)

    log('on_remove_monsters ' .. name)
    return true
end

function on_spawn_encounter(name, params)

    log('on_spawn_encounter ' .. name)
    return true
end

function on_start_long_rest(name, params)

    log('on_start_long_rest ' .. name)
    return true
end

function on_teleport(name, params)

    log('on_teleport ' .. name)
    return true
end  

--
-- name is the contender
-- battle is class GameLocationBattle
--

function on_battle_start(name, battle)

    total_contenders = actors.Count - 1
    log('on_battle_start with ' .. total_contenders .. ' contenders')
    return true
end

function on_round_start(name, battle)

    total_contenders = actors.Count - 1
    log('on_round_start with ' .. total_contenders .. ' contenders')
    return true
end

function on_turn_start(name, battle)

    log('on_turn_start ' .. name)
    return true
end

function on_turn_end(name, battle)

    log('on_turn_end ' .. name)
    return true
end

function on_battle_end(name, battle)

    log('on_battle_end ' .. name)
    return true
end