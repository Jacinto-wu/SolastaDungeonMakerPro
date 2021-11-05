--
-- start a random seed
--
math.randomseed(os.clock()*100000000000)

function random(x, y)
    x = x or 0
    y = y or 20
    return math.random(x, y)
end

--
-- log a message to the MOD UI console
--
function log(text)
    text = text or ''
    Utils.Log(text)
end

--
-- pops up a confirmation dialog and wait without blocking the game
--
function confirm(title, text, ok, cancel)
    ok = ok or 'Message/&MessageOkTitle'
    cancel = cancel or 'Message/&MessageCancelTitle'
    text = text or ''
    Utils.Confirm(title, text, ok, cancel)
    while Utils.Result < 0 do
        coroutine.yield()
    end
    return Utils.Result
end

--
-- pops up a confirmation message and wait without blocking the game
--
function message(title, text, ok)
    ok = ok or 'Message/&MessageOkTitle'
    text = text or ''
    Utils.Message(title, text, ok)
    while Utils.Result < 0 do
        coroutine.yield()
    end
end

--
-- presents a non blocking message on screen
--
function tell(message)
    Utils.Tell(message)
end

--
-- Global Variables shortcut functions
--
function setint(variable, value)
    Utils.SetInt(variable, value)
end

function setstr(variable, value)
    Utils.SetStr(variable, value)
end

function getint(variable)
    return Utils.GetInt(variable)
end

function getstr(variable)
    return Utils.GetStr(variable)
end

--
--
--
function addguest(name)
    Utils.AddGuest(name)
end

function removeguest(name)
    Utils.RemoveGuest(name)
end

function movenpc(name, x, y)
    Utils.MoveNPC(name, x, y)
end