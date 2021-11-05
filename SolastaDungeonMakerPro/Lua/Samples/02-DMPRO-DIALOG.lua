function on_force_banter_line(name, params)

    if name == "NpcBanter1" then
        return on_npc_banter1()
    elseif name == "NpcBanter2" then
        return on_npc_banter2()
    elseif name == "NpcBanter3" then
        return on_npc_banter3()
    end

    return true
end

function on_npc_banter1()

    quest_state = getint("npc_banter1_quest")

    if quest_state == 0 then
        answer = confirm("Hello", "I have a favor to ask. Would you help me?")
        if answer == 1 then
            setint("npc_banter1_quest", 1)
            message("Hello", "Please save my friend at the other side of this room.")
        end

    elseif quest_state == 1 then
        message("Hello", "Why is it taking so long?")

    elseif quest_state == 2 then
        setint("npc_banter1_quest", 3)
        message("Hello", "Thank you. My friend is saved.")
        removeguest(party[4].Name)
    end

    return quest_state == 3
end

function on_npc_banter2()

    quest_state = getint("npc_banter1_quest")

    if quest_state == 0 then
        return false

    elseif quest_state == 1 then
        setint("npc_banter1_quest", 2)
        message("Hello", "You found me. Please take me back home.")
        name = actors[0].Name
        addguest(name)
    end

    return quest_state == 3
end

function on_npc_banter3()

    quest_state = getint("npc_banter3_quest")

    if quest_state == 0 then
        answer = confirm("Hello", "Should I move now to the other side?")
        if answer == 1 then
            name = actors[0].name
            movenpc(name, 10, 10)
            setint("npc_banter3_quest", 1)
        end
    end

    return quest_state == 1
end