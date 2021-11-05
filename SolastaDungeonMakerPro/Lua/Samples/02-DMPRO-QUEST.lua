function on_force_banter_line(name, params)

    if actors.Count > 0 then
        actor = actors[0]
        granted = getint(actor.Name)
        if granted <= 0 then    
            if actor.Class == "Fighter" or actor.Class == "Paladin" then
                setint(actor.Name, 1)
                message("Hello", "I can see you like a good melee. Take a longsword", "Capiche!")
                actor.GrantItem(Helpers.ItemDefinitions.Longsword)
            elseif actor.Class == "Ranger" or actor.Class == "Rogue" then
                setint(actor.Name, 1)
                message("Hello", "I can see you like to keep your distance. Take a shortbow", "Prego!")
                actor.GrantItem(Helpers.ItemDefinitions.Shortbow)
            elseif actor.Class == "Wizard" or actor.Class == "Sorcerer" then
                setint(actor.Name, 1)
                message("Hello", "I cannot understand any stuff that you do but I fully respect you", "Ciao Bello!")
                actor.GrantItem(Helpers.ItemDefinitions.Dagger)
            else
                setint(actor.Name, granted - 1)
                if granted == 0 then
                    message("Hello", "Sorry, I have nothing for you my friend.")
                else
                    message("Hello", "Sorry, I have nothing for you my friend. " .. -granted .. " times you ask now.")
                end
            end
        else
            message("Hello", "Dont be greed. I already granted you something...")
        end
        return false
    end
    return true
    
end